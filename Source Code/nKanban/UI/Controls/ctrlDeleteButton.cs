using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nKanban.UI.Controls
{
    public partial class ctrlDeleteButton : Button
    {
        public ctrlDeleteButton()
        {
            InitializeComponent();

            // Set the button appearances
            this.BackgroundImage = Properties.Resources.recycle_bin_32;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.FlatStyle = FlatStyle.Flat;

            this.Text = string.Empty;
            // Set the button size
            this.Size = new Size(32, 32);

            // set drop for that button
            this.AllowDrop = true;

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
                task.Dispose();
            }
        }

    }
}
