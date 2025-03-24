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
    public class ProgressEntityConfiguration : IEntityTypeConfiguration<ToDoProgress>
    {
        public void Configure(EntityTypeBuilder<ToDoProgress> builder)
        {
            builder.ToTable("T_PROGRESS");
            builder.HasKey(p => p.Id).HasName("pk_progress");

            builder.Property(p => p.Progress).HasMaxLength(20).IsRequired();
        }
    }
}