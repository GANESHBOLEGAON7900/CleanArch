﻿using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyCleanProject1.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        private readonly ILogger _logger;
        public CategoryRepository(ApplicationDbContext dbContext, ILogger<Category> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            _logger.LogInformation("GetCategoriesWithEvents Initiated");
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if(!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return allCategories;
        }

        public async Task<Category> AddCategory(Category category)
        {
            //var categoryId = Guid.NewGuid();
            //List<SqlParameter> parms = new List<SqlParameter>
            //    {
            //        // Create parameter(s)
            //        new SqlParameter { ParameterName = "@CategoryId", Value = categoryId },
            //        new SqlParameter { ParameterName = "@Name", Value = category.Name },
            //    };
            //await StoredProcedureCommandAsync("CreateCategory", parms.ToArray());
            //category = await GetByIdAsync(categoryId);
            return category;
        }
    }
}
