#pragma warning disable WFO1000


using nKanban.Models;
using nKanban.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                    btnContentView.Image = Resources.closed_32;
                    pnlBody.Visible = true;
                    lblTitle.Text = txtTitle.Text;
                    this.Height = pnlHeader.Height;
                }
                else
                {
                    btnContentView.Image = Resources.opened_32;
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

        public ComboBox TaskStatus
        {
            get { return cbTaskStatus; }
            set
            {
                cbTaskStatus = value;
            }
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


            AddChildControlToMouseDownEvent(this);
        }

        private void AddChildControlToMouseDownEvent(Control parent)
        {
            // Add the MouseDown event handler to the parent control
            //parent.MouseDown += new MouseEventHandler(ctrlTaskViewer_MouseDown);

            foreach (Control control in parent.Controls)
            {

                if (control is Panel ||control is GroupBox || control is Label)
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
    }
}
