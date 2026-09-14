#pragma warning disable WFO1000


using nKanban.Models.Dtos;
using nKanban.Properties;

namespace nKanban.UI
{
    public partial class ctrlTaskViewer : UserControl
    {

        private (int Height, int Width) _OriginalSize;// Store the original size of the control

        private Boolean _IsCollapsed = false;
        public Boolean IsCollapsed
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

        public string TaskTitle
        {
            set { txtTitle.Text = value; }
            get { return txtTitle.Text; }
        }

        public string CurrentStatus
        {
            get { return cbTaskStatus.SelectedItem as string; }
            set { cbTaskStatus.SelectedItem = value; }
        }

        public string TaskDescription
        {
            set { txtDescription.Text = value; }
            get { return txtDescription.Text; }
        }

        public ctrlTaskViewer(TaskDetails details)
        {
            InitializeComponent();

            txtTitle.Text = details.TaskName;
            txtDescription.Text = details.TaskDescription;
            cbTaskStatus.SelectedItem = details.TaskStatus;
            _OriginalSize = (this.Height, this.Width);

            IsCollapsed = true;

            AddChildControlToMouseDownEvent(this);
        }

        private void AddChildControlToMouseDownEvent(Control parent)
        {
            // Add the MouseDown event handler to the parent control
            //parent.MouseDown += new MouseEventHandler(ctrlTaskViewer_MouseDown);

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


        private void btnContentView_Click(object sender, EventArgs e)
        {
            IsCollapsed = !_IsCollapsed;
        }

        private void ctrlTaskViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        public TaskDetails ToTaskDetails()
        {
            return new TaskDetails()
            {
                TaskName = txtTitle.Text,
                TaskDescription = txtDescription.Text,
                TaskStatus = CurrentStatus
            };
        }

    }
}
