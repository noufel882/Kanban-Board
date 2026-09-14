using nKanban.Models.Dtos;
using System.Diagnostics;
using static nKanban.Global;

namespace nKanban
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CurrentBoard = new([pnlToDo, pnlInProgress, pnlDone]);

            this.Text = "New Board - Empty ";

            this.KeyPreview = true;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var addTaskForm = new frmAddEditTask())
            {
                addTaskForm.TaskAdded += AddTask;
                addTaskForm.ShowDialog();
            }
        }

        private void AddTask(object sender, TaskDetails task)
        {
            CurrentBoard.AddTask(task);
        }

        private void btnSaveBoard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CurrentBoard.Path))
            {
                CurrentBoard.CommitChanges();
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
                    this.Text = CurrentBoard.Path;
                }
            }
        }

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
                    this.Text = CurrentBoard.Path;
                }
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S)
            {
                btnSaveBoard.PerformClick();

                #if DEBUG
                    Debug.WriteLine($"\nControl pressed : {e.Control} , secondary key : {e.KeyCode}\n");
                #endif

                e.SuppressKeyPress = true;
            }


        }
    }
}
