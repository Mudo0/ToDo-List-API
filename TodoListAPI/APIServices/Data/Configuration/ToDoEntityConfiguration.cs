using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Configuration
{
    public class ToDoEntityConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.ToTable("T_TODO_ITEMS");
            builder.HasKey(p => p.Id).HasName("pk_to_do");

            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Content).HasMaxLength(500).IsRequired();
            builder.Property(p => p.IsCompleted);
            builder.Property(p => p.CreatedAt);

            //configures the relation between this table and the user table
            builder.HasOne(p => p.User).WithMany(x => x.ToDos)
                .HasForeignKey(p => p.UserId);
            //configures the relation between this table and the progress table
            builder.HasOne(p => p.Progress).WithMany(x => x.ToDos)
                .HasForeignKey(p => p.ProgressId);
        }
    }
}