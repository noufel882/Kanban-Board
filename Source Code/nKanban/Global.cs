using nKanban.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace nKanban
{
    internal class Global
    {
        public static Kanban CurrentBoard;

        public static readonly string DefaultBoardName = "New Board - Empty";
    }
}
