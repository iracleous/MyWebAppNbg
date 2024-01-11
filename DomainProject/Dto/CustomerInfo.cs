using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Dto
{
    public class CustomerInfo
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int PosId { get; set; }
        public string LocationName { get; set; }
    }
}
