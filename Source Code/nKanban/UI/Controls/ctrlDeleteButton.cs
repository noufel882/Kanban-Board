using nKanban.Properties;

namespace nKanban.UI.Controls
{
    public partial class ctrlDeleteButton : Button
    {
        public ctrlDeleteButton()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.Image = Resources.Closed_Recycle_Bin_32;
            this.Size = new System.Drawing.Size(48,48);
        }
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if(e.Data.GetDataPresent(typeof(ctrlTaskViewer)))
            {
                e.Effect = DragDropEffects.Move;
              
                this.Image = Resources.Opened_Recycle_Bin_32;
            }           
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            this.Image = Resources.Closed_Recycle_Bin_32;
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (e.Data.GetData(typeof(ctrlTaskViewer)) is ctrlTaskViewer task)
            {
                task.Dispose();               
            }
            this.Image = Resources.Closed_Recycle_Bin_32;
        }
    }
}
