using System;
using System.Collections.Generic;

namespace todoList_react.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string? TaskDetails { get; set; }

    public DateTime? CreationDate { get; set; }
}
