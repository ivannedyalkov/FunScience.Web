namespace FunScience.Test
{
    using AutoMapper;
    using FunScience.Data;
    using FunScience.Web.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Tests
    {
        private static bool testsInitialized = false;

        public static void Initialize()
        {
            if (!testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialized = true;
            }
        }

        public static DbContextOptions<FunScienceDbContext> DbOptionsSetUp()
        {
           return new DbContextOptionsBuilder<FunScienceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        } 

        public static FunScienceDbContext GetDb(DbContextOptions<FunScienceDbContext> dbOptions)
        {
            return new FunScienceDbContext(dbOptions);
        }
    }
}
