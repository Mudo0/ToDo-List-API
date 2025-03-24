using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDo : Entity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        //foreign key
        public int ProgressId { get; set; }

        //navigation key
        public ToDoProgress Progress { get; set; }

        //foreign key
        public Guid UserId { get; set; }

        //navigation key
        public User User { get; set; }
    }
}