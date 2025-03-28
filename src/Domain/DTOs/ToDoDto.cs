using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using SharedKernel;

namespace Domain.DTOs
{
    public class ToDoDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Progress { get; set; }
        public Guid UserId { get; set; }
        private IDateTimeProvider dateTimeProvider;

        public ToDoDto(string title, string content, int progress, Guid userId)
        {
            Title = title;
            Content = content;
            Progress = progress;
            UserId = userId;
        }

        public ToDo Convert(ToDoDto dto)
        {
            var entity = new ToDo
            {
                Title = dto.Title,
                Content = dto.Content,
                IsCompleted = false,
                CreatedAt = dateTimeProvider.UtcNow,
                ProgressId = dto.Progress,
                UserId = dto.UserId
            };
            return entity;
        }
    }
}