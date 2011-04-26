using System;
using System.Collections.Generic;
using System.Text;
using CSpec.Testing;
using CSpec.Extensions;

namespace Test.Common
{
    public class MyClassSpec : CSpecFacade<MyClass>
    {
        public MyClassSpec()
            : base(new MyClass())
        {
            Should(@have => ObjSpec.Total == 0);
        }

        DescribeAll describe_sum =
            (@it, @do) =>
            {
                @it("Sums two numbers, given 1 and 1 it should be 2");
                @do.Sum(1, 1).Should(@be => 2);
            };

        DescribeAll describe_sub =
            (@it, @do) =>
            {
                @it("Substracts two numbers, given 1 and 3 it should be -2");
                @do.Sub(1, 3).Should(@be => -2);
            };

        DescribeAll describe_total =
            (@it, @do) =>
            {
                @do = new MyClass();
                @it("Describes total ammount, given sum of 1,2 and 3 total should have apropriate value 6");
                @do.Sum(1, 2);
                @it("We summed 1 and 2 now we need to sum 3 and 0");
                @do.Sum(0, 3);
                @do.Total.Should(@be => 6);
            };
    }
}
