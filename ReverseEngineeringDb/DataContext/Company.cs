using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseEngineeringDb.DataContext
{
    public class Company
    {
        [Key]
        public int Key { get; set; }
        [MaxLength(255)]
        public string CompanyName { get; set; }
        public ICollection<CompanyCompanyType> CompanyCompanyTypes { get; set; }
        public Address Address { get; set; }

        public Company()
        {
            CompanyCompanyTypes = new List<CompanyCompanyType>();
        }


    }

    public class Address
    {
        [Key]
        public int CompanyKey { get; set; }
        [MaxLength(100)]
        public string StreetName { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }

        private Company Company { get; set; }
    }
}
