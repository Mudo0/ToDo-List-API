using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TodoStatus Status { get; set; }
        public bool IsCompleted { get; set; } = false;

        public Guid UserId { get; set; }

        //navigation property
        public User User { get; set; }

        public void MakeCompleted()
        {
            if (Status == TodoStatus.Completed)
            {
                IsCompleted = true;
            }
        }

        public void ChangeStatus(TodoStatus status)
        {
            Status = status;
        }
    }

    
}