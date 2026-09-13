using nKanban.Models;
using nKanban.UI;

namespace nKanban
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var addTaskForm = new frmAddTask())
            {
                addTaskForm.AddTaskDelegate += AddTask;
                addTaskForm.ShowDialog();
            }
        }


        private void AddTask(object sender, TaskDetails task)
        {
            var taskItem = new ctrlTaskViewer(task);

            switch (task.TaskStatus)
            {
                case "To Do":
                    pnlToDo.Controls.Add(taskItem);
                    break;
                case "In Progress":
                    pnlInProgress.Controls.Add(taskItem);
                    break;
                case "Done":
                    pnlDone.Controls.Add(taskItem);
                    break;
            }


        }

    }
}
