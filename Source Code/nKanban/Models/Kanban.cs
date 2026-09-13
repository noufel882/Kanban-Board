using nKanban.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace nKanban.Models
{
    public  class Kanban
    {
        private Control[] _KanbanLists;

        public Kanban(Control[] KanbanLists)
        {               
            this._KanbanLists = KanbanLists;
        }

        private  static void SelectPanel(ctrlTaskViewer task, Control[] candidateParents)
        {
            foreach (Control parent in candidateParents)
            {
                if (parent is null) throw new ArgumentNullException(nameof(parent));

                if (string.Equals(task.TaskStatus.SelectedItem?.ToString(), parent.Tag?.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    parent.Controls.Add(task);
                    return;
                }

            }

            throw new Exception($"Can't match that task status = '{task.TaskStatus.SelectedItem}' with any parent in [{string.Join(", ", candidateParents)}]");
        }

        public void AddTask(TaskDetails task)
        {
            var taskItem = new ctrlTaskViewer(task);
            SelectPanel(taskItem, _KanbanLists);
        }
        
    }
}
