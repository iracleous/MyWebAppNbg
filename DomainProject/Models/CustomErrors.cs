using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Models
{
    public static  class CustomErrors
    {
        public static int OK { get; } = 0;
        public static int NULL_INPUT { get; } = 1;
        public static int EXCEPTION { get; } = 2;
    }
        
}
