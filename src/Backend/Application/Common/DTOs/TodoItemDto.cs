using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.DTOs
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TodoStatus Status { get; set; }
    }
}