using nKanban.Models.Dtos;

namespace nKanban
{
    public partial class frmAddEditTask : Form
    {
        public event EventHandler<TaskDetails> TaskAdded;

        protected void OnNewTaskAdded(TaskDetails task)
        {
            var handler = TaskAdded;
            handler?.Invoke(this, task);
        }

     
        public frmAddEditTask()
        {
            InitializeComponent();
            cbTaskStatus.SelectedIndex = 0; // Set default selection to "To Do"
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("The task title is require !", "Note", MessageBoxButtons.OK);
                return;
            }

            TaskDetails newTask = new TaskDetails
            {
                TaskName = txtTitle.Text,
                TaskDescription = txtDescription.Text,
                TaskStatus = (string)cbTaskStatus.SelectedItem
            };

            OnNewTaskAdded(newTask);
            this.Close();

        }

    }
}
