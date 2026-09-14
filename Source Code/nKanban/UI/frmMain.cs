using nKanban.Models;
using nKanban.UI;
using static nKanban.Models.Global;

namespace nKanban
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            CurrentBoard = new([pnlToDo, pnlInProgress, pnlDone]);
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
                }
            }
        }
    }
}
