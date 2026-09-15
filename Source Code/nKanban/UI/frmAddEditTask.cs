using nKanban.Models.Dtos;

namespace nKanban
{
    /// <summary>
    /// Represents a dialog form for creating new task details.
    /// </summary>
    public partial class frmAddTask : Form
    {
        /// <summary>
        /// Occurs when a new task is confirmed and submitted from the form.
        /// </summary>
        public event EventHandler<TaskDetails> TaskAdded;

        /// <summary>
        /// Raises the <see cref="TaskAdded"/> event with the newly created task details.
        /// </summary>
        /// <param name="task">The task details data transfer object.</param>
        protected void OnNewTaskAdded(TaskDetails task)
        {
            var handler = TaskAdded;
            handler?.Invoke(this, task);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddTask"/> class and sets default status selection.
        /// </summary>
        public frmAddTask()
        {
            InitializeComponent();

            // Set default status selection (e.g., "To Do")
            cbTaskStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the Close button to dismiss the dialog without saving.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the Confirm button to validate inputs, trigger the creation event, and close the dialog.
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate that the task title is not empty or whitespace
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("The task title is required!", "Note", MessageBoxButtons.OK);
                return;
            }

            // Create a new DTO populated from user inputs
            TaskDetails newTask = new TaskDetails
            {
                TaskName = txtTitle.Text,
                TaskDescription = txtDescription.Text,
                TaskStatus = (string)cbTaskStatus.SelectedItem
            };

            // Dispatch event to listeners and close the form
            OnNewTaskAdded(newTask);
            this.Close();
        }
    }
}