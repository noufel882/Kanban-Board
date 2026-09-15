using System;

namespace nKanban.Models.Dtos
{
    /// <summary>
    /// Represents the data transfer object containing task information.
    /// </summary>
    public class TaskDetails
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public string TaskName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the detailed description of the task.
        /// </summary>
        public string TaskDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current status of the task.
        /// </summary>
        public string TaskStatus { get; set; } = string.Empty;
    }
}