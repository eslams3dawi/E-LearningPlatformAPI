using ELearningPlatform.DAL.Database;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Repository.CourseRepository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ELearningContext context) : base(context)
        {

        }
    }
}
