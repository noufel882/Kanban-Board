using nKanban.Models.Domain;
using nKanban.Models.Dtos;
using nKanban.UI;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nKanban.Services
{
    internal static class StorageService
    {
        public static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true, 
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
        };

        private static List<TaskDetails> GetBoardData(Kanban board)
        {
            var tasks = new List<TaskDetails>();

            foreach(Control list in board.KanbanLists)
            {
                foreach(ctrlTaskViewer item in list.Controls)
                {
                    tasks.Add(item.ToTaskDetails());
                }
            }

            return tasks;
        }

        public static void SaveBoardData(Kanban board,string filePath)
        {
            var data = GetBoardData(board);

            string json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(filePath,json);           
        }

        public static List<TaskDetails> LoadBoardData(string filePath)
        {
            if (!File.Exists(filePath)) return new List<TaskDetails>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<TaskDetails>>(json, options) ?? new List<TaskDetails>();
        }


    }
}
