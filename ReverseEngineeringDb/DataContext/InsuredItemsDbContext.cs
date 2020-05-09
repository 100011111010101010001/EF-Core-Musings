using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReverseEngineeringDb.DataContext
{
    public class InsuredItemsDbContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer($"Data Source=localhost;Initial Catalog={dbname};Persist Security Info=True;User ID=sa;Password=sa;MultipleActiveResultSets=True;App=EntityFramework");

        }

        private static string dbname = "V1V870BSJJN";
        //private static string dbname = RandomString(11);
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
