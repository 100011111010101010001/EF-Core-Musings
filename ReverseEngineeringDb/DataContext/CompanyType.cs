using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseEngineeringDb.DataContext
{
    public class CompanyType
    {
        [Key]
        public int TypeKey { get; set; }
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
