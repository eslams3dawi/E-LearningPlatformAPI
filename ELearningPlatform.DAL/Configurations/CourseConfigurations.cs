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
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.CourseName)
                .HasMaxLength(40);
            //builder.Property(c => c.Category)
            //    .HasMaxLength(50);
        }
    }
}
