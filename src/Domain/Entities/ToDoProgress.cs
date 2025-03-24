using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoProgress
    {
        public int Id { get; set; }
        public string Progress { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}