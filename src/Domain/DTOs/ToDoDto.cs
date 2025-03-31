using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using SharedKernel;

namespace Domain.DTOs
{
    public class ToDoDto : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Progress { get; set; }
        public Guid UserId { get; set; }

        public ToDoDto(string title, string content, int progress, Guid userId)
        {
            Title = title;
            Content = content;
            Progress = progress;
            UserId = userId;
        }

        public ToDo Convert()
        {
            var entity = new ToDo
            {
                Id = Id,
                Title = Title,
                Content = Content,
                IsCompleted = false,
                //todo corregir
                CreatedAt = dateTimeProvider.UtcNow,
                ProgressId = Progress,
                UserId = UserId
            };
            return entity;
        }
    }
}