#pragma warning disable WFO1000
using nKanban.Models.Dtos;
using nKanban.Properties;

namespace nKanban.UI
{
    /// <summary>
    /// Represents a visual task viewer control that displays and manages task details and drag operations.
    /// </summary>
    public partial class ctrlTaskViewer : UserControl
    {
        /// <summary>
        /// Stores the initial height and width of the control to restore during expand operations.
        /// </summary>
        private (int Height, int Width) _OriginalSize;

        private bool _IsCollapsed = false;

        /// <summary>
        /// Gets or sets a value indicating whether the task card body is collapsed or expanded.
        /// </summary>
        public bool IsCollapsed
        {
            set
            {
                _IsCollapsed = value;

                if (_IsCollapsed)
                {
                    btnContentView.Image = Resources.Arrow_Right_32;
                    pnlBody.Visible = true;
                    lblTitle.Text = txtTitle.Text;
                    this.Height = pnlHeader.Height;
                }
                else
                {
                    btnContentView.Image = Resources.Arrow_DOWN_32;
                    lblTitle.Text = null;
                    pnlBody.Visible = true;
                    this.Height = _OriginalSize.Height;
                }
            }
            get { return _IsCollapsed; }
        }

        /// <summary>
        /// Gets or sets the title text of the task.
        /// </summary>
        public string TaskTitle
        {
            set { txtTitle.Text = value; }
            get { return txtTitle.Text; }
        }

        /// <summary>
        /// Gets or sets the current status of the task from the status combo box.
        /// </summary>
        public string CurrentStatus
        {
            get { return cbTaskStatus.SelectedItem as string; }
            set { cbTaskStatus.SelectedItem = value; }
        }

        /// <summary>
        /// Gets or sets the description text of the task.
        /// </summary>
        public string TaskDescription
        {
            set { txtDescription.Text = value; }
            get { return txtDescription.Text; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ctrlTaskViewer"/> class using data from a <see cref="TaskDetails"/> DTO.
        /// </summary>
        /// <param name="details">The task details data source.</param>
        public ctrlTaskViewer(TaskDetails details)
        {
            InitializeComponent();

            txtTitle.Text = details.TaskName;
            txtDescription.Text = details.TaskDescription;
            cbTaskStatus.SelectedItem = details.TaskStatus;
            _OriginalSize = (this.Height, this.Width);

            IsCollapsed = true;

            // Register drag handlers recursively across child container controls
            AddChildControlToMouseDownEvent(this);
        }

        /// <summary>
        /// Recursively attaches the MouseDown event handler to nested non-interactive child controls to support drag initiation.
        /// </summary>
        /// <param name="parent">The parent control container to traverse.</param>
        private void AddChildControlToMouseDownEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Panel || control is GroupBox || control is Label)
                {
                    control.MouseDown += new MouseEventHandler(ctrlTaskViewer_MouseDown);
                    if (control.HasChildren)
                    {
                        AddChildControlToMouseDownEvent(control);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the click event of the expand/collapse button to toggle the card view state.
        /// </summary>
        private void btnContentView_Click(object sender, EventArgs e)
        {
            IsCollapsed = !_IsCollapsed;
        }

        /// <summary>
        /// Handles the MouseDown event on the control or its children to initiate a drag-and-drop operation.
        /// </summary>
        private void ctrlTaskViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Converts the current UI control values into a <see cref="TaskDetails"/> data transfer object.
        /// </summary>
        /// <returns>A new <see cref="TaskDetails"/> instance populated with current control state.</returns>
        public TaskDetails ToTaskDetails()
        {
            return new TaskDetails()
            {
                TaskName = txtTitle.Text,
                TaskDescription = txtDescription.Text,
                TaskStatus = CurrentStatus
            };
        }


        public override string ToString()
        {

            return $"({txtTitle},{txtDescription},{CurrentStatus})";
        }

    }
}