using System;
using System.Collections.Generic;
using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Entities;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbContextOptions<DataficationDbContext> options;
        public int CreateNewCategory(CategoryInputModel category)
        {

            // var contextOptions = new DbContextOptionsBuilder<DataficationDbContext>()
            //.UseSqlite(@"Server=(localdb)\mssqllocaldb;Database=Test")
            //.Options;

            using var dbContext = new DataficationDbContext();

            var newCategory = new Category
            {
                Name = category.Name,
                ParentCategoryId = (int)category.ParentCategoryId
            };
            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();

            return newCategory.Id;
        }

        public void DeleteCategory(int id)
        {
            using var dbContext = new DataficationDbContext();

            var oneCategory = dbContext
                .Categories
                .Find(id);

            dbContext.Categories.Remove(oneCategory);
            dbContext.SaveChanges();
        }

        public IEnumerable<IceCreamDto> GetIceCreamsByCategoryId(int id)
        {
            using var dbContext = new DataficationDbContext();

            var allCategoryById = dbContext
                .Categories
                .Where(C => C.Id == id)
                .Include(entity => (dbContext
                                    .Categories
                                    .Where(C => C.Id == entity.ParentCategoryId)
                                    .ElementAtOrDefault(0)));
            

            // this only works for one level upp
            var allIceCreamsByCategoryId_notFinal = allCategoryById.ElementAtOrDefault(0).IceCreams.Concat(allCategoryById.ElementAtOrDefault(1).IceCreams);
            

            var allIceCreamsByCategoryId_Final = allIceCreamsByCategoryId_notFinal.Select(I => new IceCreamDto
            {
                Id = I.Id,
                Name = I.Name,
                Description = I.Description
            });

            return allIceCreamsByCategoryId_Final;


           
        }
    }
}