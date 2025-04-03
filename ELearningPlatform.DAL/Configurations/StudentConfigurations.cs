using ELearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(s => s.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(s => s.Age)
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(s => s.Gender)
                .HasMaxLength(6)
                .IsRequired();
            builder.Property(s => s.EnrollmentDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
