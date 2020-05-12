using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReverseEngineeringDb.DataContext
{
    public class CompanyCompanyType
    {
        public int CompanyKey { get; set; }
        public int CompanyTypeKey { get; set; }


        public Company Company { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}