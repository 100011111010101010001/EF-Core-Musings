﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ReverseEngineeringDb.DataContext
{
    public class InsuredItemsDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(Configure);


        private static void Configure(ILoggingBuilder builder)
        {
            builder.AddConsole();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }

        public DbSet<Blog> Blogs { get; set; }


        public InsuredItemsDbContext(DbContextOptions<InsuredItemsDbContext> options) : base(options)
        {

        }

        public InsuredItemsDbContext() : base(new DbContextOptionsBuilder<InsuredItemsDbContext>().UseLoggerFactory(MyLoggerFactory).UseSqlServer($"Data Source=localhost;Initial Catalog={dbname};Persist Security Info=True;User ID=sa;Password=sa;MultipleActiveResultSets=True;App=EntityFramework").Options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



        }

        private static string dbname = "v123";
        //private static string dbname = RandomString(11);
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<CompanyCompanyType>().HasKey(c => new { c.CompanyKey, c.CompanyTypeKey });
        }
    }
}
