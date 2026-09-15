using nKanban.Models.Dtos;
using nKanban.Services;
using nKanban.UI;

namespace nKanban.Models.Domain
{
    /// <summary>
    /// Represents a Kanban board, managing task placement across columns and board persistence.
    /// </summary>
    public class Kanban
    {
        /// <summary>
        /// Gets or sets the visual control containers representing the board columns.
        /// </summary>
        public Control[] KanbanColumns;

        /// <summary>
        /// Gets or sets the file path associated with the current board instance.
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Kanban"/> class with target columns.
        /// </summary>
        /// <param name="columns">The array of control containers acting as columns.</param>
        public Kanban(Control[] columns)
        {
            this.KanbanColumns = columns;
        }

        /// <summary>
        /// Matches a task control to a target column based on its status tag and adds it to that column.
        /// </summary>

        /// <exception cref="ArgumentNullException">Thrown when a column reference in the array is null.</exception>
        /// <exception cref="Exception">Thrown when no column matches the task status.</exception>
        private static void SelectColumn(ctrlTaskViewer task, Control[] candidateColumn)
        {
            foreach (Control column in candidateColumn)
            {
                if (column is null) throw new ArgumentNullException(nameof(column));

                // Match task status against column Tag property (case-insensitive)
                if (string.Equals(task.CurrentStatus, column.Tag?.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    column.Controls.Add(task);
                    return;
                }
            }

            throw new Exception($"Can't match that task status = '{task.CurrentStatus}' with any parent in [{string.Join(", ", candidateColumn)}]");
        }

        /// <summary>
        /// Creates a visual task control from details and assigns it to its corresponding column.
        /// </summary>
        /// <param name="task">The task details data model.</param>
        public void AddTask(TaskDetails task)
        {
            var taskItem = new ctrlTaskViewer(task);
            SelectColumn(taskItem, KanbanColumns);
        }

        /// <summary>
        /// Resets the file path and clears all task controls from every column.
        /// </summary>
        public void Clear()
        {
            this.Path = string.Empty;
            foreach (Control column in this.KanbanColumns)
            {
                column.Controls.Clear();
            }
        }

        /// <summary>
        /// Saves the current state of the board to a specified file path.
        /// </summary>
        /// <param name="filePath">The target file path for saving data.</param>
        public void Save(string filePath)
        {
            StorageService.SaveBoardData(this, filePath);
            Path = filePath ?? Path;
        }

        /// <summary>
        /// Load a <see cref="Kanban"/> board from a file.
        /// </summary>
        /// <param name="filePath">The source file path to read board data from.</param>
        public void Load(string filePath)
        {
            var tasks = StorageService.LoadBoardData(filePath);

            if (tasks is null || tasks.Count == 0) return;

            // Clear the current board 
            this.Clear();

            foreach (var task in tasks)
            {
                var taskViewer = new ctrlTaskViewer(task);
                SelectColumn(taskViewer, KanbanColumns);
            }

            Path = filePath ?? string.Empty;
        }

        /// <summary>
        /// Persists changes back to the currently loaded file path.
        /// </summary>
        public void CommitChanges()
        {
            Save(this.Path);
        }

        /// <summary>
        /// Searches across all board columns, removes the specified task control instance, and disposes of its resources.
        /// </summary>
        /// <param name="taskViewer">The target task control instance to delete from the board.</param>
        public void Delete(ctrlTaskViewer taskViewer)
        {
            if (taskViewer is null) return;

            foreach (Control column in this.KanbanColumns)
            {
                // Internally searches for the matching control reference and removes it safely if present
                column.Controls.Remove(taskViewer);
            }

            // Safely release UI handle resources after clearing references from parent controls
            taskViewer.Dispose();
        }

    }
}