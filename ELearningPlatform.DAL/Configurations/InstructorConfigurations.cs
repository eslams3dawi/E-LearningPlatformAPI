using ELearningPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Configurations
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(i => i.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(i => i.Age)
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(i => i.ExperienceYears)
                .HasMaxLength(2);
            builder.Property(i => i.Salary)
                .HasPrecision(12, 2)
                .IsRequired();
            builder.Property(i => i.Specialization)
                   .HasMaxLength(35)
                   .IsRequired();
        }
    }
}
