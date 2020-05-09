using System;
using System.Linq;
using NUnit.Framework;
using ReverseEngineeringDb.DataContext;

namespace ReverseEngineeringDb
{
    [TestFixture]
    public class Class1
    {

        [Test]
        public void TestAddCompanyType()
        {
            var dbcontext = new InsuredItemsDbContext();

            for (int i = 0; i < 100; i++)
            {
                var companytype = new CompanyType();
                companytype.TypeName = RandomString(21);
                dbcontext.CompanyType.Add(companytype);
            }

            dbcontext.SaveChanges();
        }

        [Test]
        public void TestAddCompanyToCompanyType()
        {
            var db = new InsuredItemsDbContext();
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string chars = "10";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        [Test]
        public void Test1()
        {
            Console.WriteLine("First core test");
            Assert.IsTrue(true);

            var dbcontext = new InsuredItemsDbContext();
            //dbcontext.Database.EnsureCreated();
            Assert.IsNotNull(dbcontext);
            var list = dbcontext.Companies.ToList();
            Assert.IsNotNull(list);
        }
    }
}
