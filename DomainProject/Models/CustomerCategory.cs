using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Models
{
    public enum CustomerCategory
    {
        [Display(Name = "Internet Customer")] INTERNET = 1,
        [Display(Name = "Retail Customer")] RETAIL = 2,
        [Display(Name = "Gross Customer")] GROSS = 5,
    }
}
