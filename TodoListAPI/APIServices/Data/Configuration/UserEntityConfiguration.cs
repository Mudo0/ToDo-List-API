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
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_USERS");
            builder.HasKey(p => p.Id).HasName("pk_users");

            builder.Property(p => p.Username).HasMaxLength(20).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}