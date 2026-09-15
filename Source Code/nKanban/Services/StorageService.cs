using nKanban.Models.Domain;
using nKanban.Models.Dtos;
using nKanban.UI;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nKanban.Services
{
    /// <summary>
    /// Provides functionality for serializing and deserializing board data to and from JSON files.
    /// </summary>
    internal static class StorageService
    {
        /// <summary>
        /// Gets the JSON serialization and deserialization configuration options.
        /// </summary>
        public static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            // Formats the JSON output with indentation for better readability
            WriteIndented = true,

            // Allows case-insensitive property matching during deserialization
            PropertyNameCaseInsensitive = true,

            // Prevents escaping of special characters like HTML tags or Unicode symbols
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

            // Omits properties from the output JSON if their value is null
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        /// <summary>
        /// Extracts all task data objects from the controls of each board column.
        /// </summary>
        /// <param name="board">The Kanban board instance containing columns and controls.</param>
        /// <returns>A list of <see cref="TaskDetails"/> extracted from the UI controls.</returns>
        private static List<TaskDetails> GetBoardData(Kanban board)
        {
            var tasks = new List<TaskDetails>();

            foreach (Control list in board.KanbanColumns)
            {
                foreach (ctrlTaskViewer item in list.Controls)
                {
                    tasks.Add(item.ToTaskDetails());
                }
            }

            return tasks;
        }

        /// <summary>
        /// Serializes the current state of a Kanban board and writes it to a file.
        /// </summary>
        /// <param name="board">The Kanban board instance to save.</param>
        /// <param name="filePath">The absolute or relative target file path.</param>
        public static void SaveBoardData(Kanban board, string filePath)
        {
            var data = GetBoardData(board);

            string json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Reads a JSON file and deserializes its contents into a list of tasks.
        /// </summary>
        /// <param name="filePath">The source file path to read from.</param>
        /// <returns>A list of <see cref="TaskDetails"/> if the file exists and contains valid data; otherwise, an empty list.</returns>
        public static List<TaskDetails> LoadBoardData(string filePath)
        {
            if (!File.Exists(filePath)) return new List<TaskDetails>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<TaskDetails>>(json, options) ?? new List<TaskDetails>();
        }
    }
}