﻿using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Repository.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
