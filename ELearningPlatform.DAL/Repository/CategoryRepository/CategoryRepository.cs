﻿using ELearningPlatform.DAL.Database;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Repository.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ELearningContext eLearningContext) : base(eLearningContext)
        {
        }
    }
}
