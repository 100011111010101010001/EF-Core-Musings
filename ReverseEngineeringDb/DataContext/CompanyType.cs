using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseEngineeringDb.DataContext
{
    public class CompanyType
    {
        [Key]
        public int Key { get; set; }
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        public ICollection<CompanyCompanyType> CompanyCompanyTypes { get; set; }

        public CompanyType()
        {
            CompanyCompanyTypes = new List<CompanyCompanyType>();
        }
    }
}

