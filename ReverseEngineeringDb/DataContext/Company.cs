using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseEngineeringDb.DataContext
{
    public class Company
    {
        [Key]
        public int CompanyKey { get; set; }
        [MaxLength(255)]
        public string CompanyName { get; set; }
        public CompanyType CompanyTypes { get; set; }

        public Company()
        {
           
        }
    }
}
