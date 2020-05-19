using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ReverseEngineeringDb.DataContext;

namespace ReverseEngineeringDb
{
    [TestFixture]
    public class InsuredItemsDbContextTestFixture
    {

        private const string BinaryString = "10";
        private const string AllChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


        [Test]
        public void TestAddAddressToCompany()
        {
            using (var db = new InsuredItemsDbContext())
            {
                foreach (var company in db.Companies.Include(c => c.Address))
                {
                    if (company.Address == null)
                        company.Address = new Address();
                    company.Address.Country = RandomString(10, AllChars);
                    company.Address.StreetName = RandomString(21, AllChars);
                }

                db.SaveChanges();
            }
        }

        [Test]
        public void TestGetCompaniesWithAddress()
        {
            IList<Company> list;
            using (var db = new InsuredItemsDbContext())
            {
                list = db.Companies.Include(c => c.Address).Where(c => c.Address != null).ToList();
            }

            foreach (var company in list)
            {
                Console.WriteLine($"{company.CompanyName}    address:{company.Address.StreetName}");
            }
        }

        [Test]
        public void TestAddCompanyType()
        {
            var dbcontext = new InsuredItemsDbContext();

            for (int i = 0; i < 100; i++)
            {
                var companytype = new CompanyType();
                companytype.TypeName = RandomString(21, BinaryString);
                dbcontext.CompanyTypes.Add(companytype);
            }

            dbcontext.SaveChanges();
        }

        [Test]
        public void TestAddCompanyToCompanyType()
        {
            var db = new InsuredItemsDbContext();
            foreach (var companyType in db.CompanyTypes)
            {
                var company = new Company();
                company.CompanyName = RandomString(51, AllChars);
                company.CompanyCompanyTypes.Add(new CompanyCompanyType() { Company = company, CompanyType = companyType });
                db.Companies.Add(company);
            }

            db.SaveChanges();
        }

        [Test]
        public void TestGetCompanyByKey()
        {
            var db = new InsuredItemsDbContext();
            var company = db.Companies.Include(c => c.CompanyCompanyTypes).ThenInclude(c => c.CompanyType).FirstOrDefault(c => c.Key == 23);
            Assert.IsNotNull(company);
            Assert.AreEqual(company.CompanyCompanyTypes.Count, 1);
        }

        public static string RandomString(int length, string chars)
        {
            var random = new Random();

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
