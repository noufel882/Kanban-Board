using nKanban.Properties;

namespace nKanban.UI.Controls
{
    /// <summary>
    /// Represents a custom drop-target button that disposes of task controls dropped onto it.
    /// </summary>
    public partial class ctrlDeleteButton : Button
    {
        /// <summary>
        /// Occurs when a task control drag-and-drop operation completes over the button.
        /// </summary>
        public event EventHandler<DragEventArgs> TaskDelete;

        /// <summary>
        /// Raises the <see cref="TaskDelete"/> event.
        /// </summary>
        /// <param name="e">A <see cref="DragEventArgs"/> that contains the event data.</param>
        protected virtual void OnTaskDelete(DragEventArgs e)
        {
            TaskDelete?.Invoke(this, e);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ctrlDeleteButton"/> class.
        /// </summary>
        public ctrlDeleteButton()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.Image = Resources.Closed_Recycle_Bin_32;
            this.Size = new Size(48, 48);
        }

        /// <summary>
        /// Handles the drag-enter event to validate dropped data and visually update the button state.
        /// </summary>
        /// <param name="e">A <see cref="DragEventArgs"/> that contains the event data.</param>
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            // Verify if the dragged payload contains a task control
            if (e.Data.GetDataPresent(typeof(ctrlTaskViewer)))
            {
                e.Effect = DragDropEffects.Move;

                // Change icon to reflect active drop state
                this.Image = Resources.Opened_Recycle_Bin_32;
            }
        }

        /// <summary>
        /// Handles the drag-leave event to restore the default icon when the drag operation leaves the control bounds.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);

            // Revert back to the default closed bin icon
            this.Image = Resources.Closed_Recycle_Bin_32;
        }

        /// <summary>
        /// Handles the drag-drop event to trigger deletion logic and reset the button appearance.
        /// </summary>
        /// <param name="e">A <see cref="DragEventArgs"/> that contains the event data.</param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            OnTaskDelete(e);

            // Reset icon after drop completes
            this.Image = Resources.Closed_Recycle_Bin_32;
        }

    }
}