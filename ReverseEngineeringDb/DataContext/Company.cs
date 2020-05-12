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

        public Company()
        {
            CompanyCompanyTypes = new List<CompanyCompanyType>();
        }
    }
}
