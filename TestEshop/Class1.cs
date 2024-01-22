using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop;

public class Class1
{
    [Fact]
    public void TestMethod()
    {
        var expected = 1;
        var calculated = 1;
        Assert.Equal(expected, calculated);
    }
}
