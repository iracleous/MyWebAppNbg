using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Models;

public class Basket
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }

    public virtual List<Product> Products { get; set; } = [];
    public virtual Customer? Customer { get; set; }
}
