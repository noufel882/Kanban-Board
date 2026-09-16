namespace nKanban.UI.Controls
{
    /// <summary>
    /// Represents a custom column panel that hosts task controls and accepts drag-and-drop actions.
    /// </summary>
    public partial class ctrlPanel : FlowLayoutPanel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ctrlPanel"/> class.
        /// Configures layout orientation, borders, margins, and drag-and-drop settings.
        /// </summary>
        public ctrlPanel()
        {
            InitializeComponent();

            AllowDrop = true;
            BorderStyle = BorderStyle.FixedSingle;
            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            Margin = new Padding(10);
        }

        /// <summary>
        /// Handles the drag-enter event to validate whether the incoming data is a task control.
        /// </summary>
        /// <param name="e">A <see cref="DragEventArgs"/> containing event details.</param>
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            // Allow move operation if the payload matches the expected task control type
            if (e.Data.GetDataPresent(typeof(ctrlTaskViewer)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// Handles the drag-drop event to re-parent the dropped task control and update its status based on the column tag.
        /// </summary>
        /// <param name="e">A <see cref="DragEventArgs"/> containing event details.</param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            // Extract dropped task, synchronize its status with panel Tag, and update parent container
            if (e.Data.GetData(typeof(ctrlTaskViewer)) is ctrlTaskViewer task)
            {
                task.CurrentStatus = this.Tag.ToString();
                this.Controls.Add(task);
            }
        }



    }
}