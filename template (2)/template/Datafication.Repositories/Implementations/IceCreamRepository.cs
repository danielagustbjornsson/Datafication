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
    public class IceCreamRepository : IIceCreamRepository
    {
        private DbContextOptions<DataficationDbContext> options;
        public void AddIceCreamToCategory(int iceCreamId, int categoryId)
        {

            using var dbContext = new DataficationDbContext();

            var OneIceCream = dbContext
                .IceCreams
                .Find(iceCreamId);

            var oneCategory = dbContext
                .Categories
                .Find(categoryId);

            oneCategory.IceCreams.Add(OneIceCream);
            dbContext.SaveChanges();

        }

        public int CreateNewIceCream(IceCreamInputModel iceCream)
        {

            //var Response = new HttpResponseMessage(HttpStatusCode.Created);
            //Response.Headers.location = "hello";

            using var dbContext = new DataficationDbContext();
            var newIceCream = new IceCream
            {
                Name = iceCream.Name,
                Description = iceCream.Description,
                ManufacturerId = iceCream.ManufacturerId
            };

            dbContext.IceCreams.Add(newIceCream);
            dbContext.SaveChanges();

            var newIceCreaId = newIceCream.Id;
            return newIceCreaId;
            
        }

        public void DeleteIceCream(int id)
        {
            using var dbContext = new DataficationDbContext();

            var oneIceCream = dbContext
                .IceCreams
                .Find(id);

            dbContext.IceCreams.Remove(oneIceCream);
            dbContext.SaveChanges();
        }

        public IEnumerable<IceCreamDto> GetAllIceCreams()
        {
            using var dbContext = new DataficationDbContext();

            var allIceCreams = dbContext
                .IceCreams
                // Added to simplify relational fixup because 
                // this is a read - only access to the database
                .AsNoTracking()
                .Select(I => new IceCreamDto
                {
                    Id = I.Id,
                    Name = I.Name,
                    Description = I.Description

                });
            return allIceCreams;

        }

        public IceCreamDetailsDto GetIceCreamById(int id)
        {
            using var dbContext = new DataficationDbContext();

            var oneIceCream = dbContext
                .IceCreams
                // Added to simplify relational fixup because 
                // this is a read - only access to the database
                .AsNoTracking()
                .FirstOrDefault(I =>  I.Id == id);

                //.Select(I => new IceCreamDetailsDto
                //{
                //    Id = I.Id,
                //    Name = I.Name,
                //    Description = I.Description
                //}).ElementAtOrDefault(0);

            return new IceCreamDetailsDto
            {
                Id = oneIceCream.Id,
                Name = oneIceCream.Name,
                Description = oneIceCream.Description
            };

        }

        public void UpdateIceCream(int id, IceCreamInputModel iceCream)
        {
            using var dbContext = new DataficationDbContext();

            var oneIceCream = dbContext
                .IceCreams
                .Find(id);

            oneIceCream.Name = iceCream.Name;
            oneIceCream.Description = iceCream.Description;
            oneIceCream.ManufacturerId = iceCream.ManufacturerId;
            dbContext.SaveChanges();

        }
    }
}