using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Models
{
    public enum ProductCategory 
    {
        [Display(Name = "Food")] FOOD = 1, 
        [Display(Name = "Snack")] SNACK = 2, 
        [Display(Name = "Drink")] DRINK = 5,
    }
}
