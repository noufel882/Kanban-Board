using nKanban.UI;

namespace nKanban.Models
{
    public  class Kanban
    {
        public Control[] KanbanLists;
      
        public Kanban(Control[] KanbanLists)
        {               
            this.KanbanLists = KanbanLists;
        }

        private  static void SelectPanel(ctrlTaskViewer task, Control[] candidateParents)
        {
            foreach (Control parent in candidateParents)
            {
                if (parent is null) throw new ArgumentNullException(nameof(parent));

                if (string.Equals(task.CurrentStatus, parent.Tag?.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    parent.Controls.Add(task);
                    return;
                }

            }

            throw new Exception($"Can't match that task status = '{task.CurrentStatus}' with any parent in [{string.Join(", ", candidateParents)}]");
        }

        public void AddTask(TaskDetails task)
        {
            var taskItem = new ctrlTaskViewer(task);
            SelectPanel(taskItem, KanbanLists);
        }
        
        public void Clear()
        {
            foreach (Control list in this.KanbanLists)
            {
                list.Controls.Clear();
            }
        }

        public void Save(string filePath)
        {
            StorageService.SaveBoardData(this, filePath);
        }

        public void Load(string filePath)
        {
            var tasks = StorageService.LoadBoardData(filePath);

            if (tasks is null || tasks.Count == 0) return;

            this.Clear();

            foreach (var task in tasks)
            {
                var taskViewer = new ctrlTaskViewer(task);
                SelectPanel(taskViewer, KanbanLists);
            }

        }

    }
}
