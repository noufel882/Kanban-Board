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
            CurrentBoard = new([pnlToDo,pnlInProgress,pnlDone]);
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

    }
}
