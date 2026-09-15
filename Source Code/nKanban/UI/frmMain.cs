using nKanban.Models.Dtos;
using nKanban.UI;
using System.ComponentModel;
using System.Diagnostics;
using static nKanban.Global;

namespace nKanban
{
    /// <summary>
    /// Represents the main interface window managing board display, events, and file persistence.
    /// </summary>
    public partial class frmMain : Form
    {
        private bool _IsSaved = false;

        /// <summary>
        /// Gets or sets a value indicating whether current board state is synchronized to storage.
        /// Automatically manages unsaved indicators (*) within the window title bar.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSaved
        {
            get { return _IsSaved; }
            set
            {
                _IsSaved = value;

                if (!_IsSaved)
                {
                    // Ensure the unsaved indicator is appended only to the end of the text
                    if (!this.Text.EndsWith(" *"))
                    {
                        this.Text = this.Text + " *";
                    }
                }
                else
                {
                    // Restore window title to file path or default board name
                    this.Text = CurrentBoard.Path ?? DefaultBoardName;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> form.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            CurrentBoard = new([pnlToDo, pnlInProgress, pnlDone]);

            this.Text = DefaultBoardName;
            this.IsSaved = false;
            this.KeyPreview = true;
        }

        /// <summary>
        /// Opens the form dialog for adding new task items.
        /// </summary>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var addTaskForm = new frmAddTask())
            {
                addTaskForm.TaskAdded += AddTask;
                addTaskForm.ShowDialog();
            }
        }

        /// <summary>
        /// Adds a task to the board model and marks state as dirty.
        /// </summary>
        private void AddTask(object sender, TaskDetails task)
        {
            CurrentBoard.AddTask(task);
            IsSaved = false;
        }

        /// <summary>
        /// Saves changes directly to existing path or prompts dialog for selection.
        /// </summary>
        private void btnSaveBoard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CurrentBoard.Path))
            {
                CurrentBoard.CommitChanges();
                IsSaved = true;
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = "Choose save location";
                saveFileDialog.FileName = "kanban_board.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    CurrentBoard.Save(filePath);
                    IsSaved = true;
                }
            }
        }

        /// <summary>
        /// Prompts user to select and load an existing Kanban JSON file.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.DefaultExt = "json";
                openFileDialog.Title = "Choose the board";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    CurrentBoard.Load(filePath);
                    IsSaved = true; // Setter updates this.Text automatically
                }
            }
        }

        /// <summary>
        /// Handles global window key bindings like Ctrl+S.
        /// </summary>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSaveBoard.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Processes drag-and-drop task deletion dispatch from the delete button.
        /// </summary>
        private void btnDelete_TaskDelete(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(ctrlTaskViewer)) is ctrlTaskViewer task)
            {
                CurrentBoard.Delete(task);
                IsSaved = false;
            }
        }

        /// <summary>
        /// Handles the form closing event to prompt user for saving modified board changes.
        /// Prevents window closure if saving is cancelled or dismissed by the user.
        /// </summary>
        /// <param name="sender">The event source triggering the closure.</param>
        /// <param name="e">A <see cref="FormClosingEventArgs"/> providing cancellation mechanisms for the close sequence.</param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                var result = MessageBox.Show(
                    "Save changes ?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    btnSaveBoard.PerformClick();

                    // Cancel form closure if save operation was cancelled or unsuccessful
                    if (!IsSaved)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}