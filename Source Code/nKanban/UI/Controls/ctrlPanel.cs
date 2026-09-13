using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nKanban.UI.Controls
{
    public partial class ctrlPanel : FlowLayoutPanel
    {
        public ctrlPanel()
        {
            InitializeComponent();
            AllowDrop = true;
            BorderStyle = BorderStyle.FixedSingle;
            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            Margin = new Padding(10);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (e.Data.GetDataPresent(typeof(ctrlTaskViewer)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (e.Data.GetData(typeof(ctrlTaskViewer)) is ctrlTaskViewer task)
            {

                task.TaskStatus.SelectedItem = this.Tag;

                this.Controls.Add(task);
            }
        }

    }
}
