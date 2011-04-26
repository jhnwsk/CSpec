using System;
using System.Collections.Generic;
using System.Text;
using CSpec.Testing;
using CSpec.Extensions;
using Test.Common;

namespace Test.Spec
{
    public class CSpecExtensionsSpec : CSpecFacadeStatic
    {
        /*
         * Testing static classes.
         * As static classes have no instance we
         * need to skip the @do keyword
         */
        
        DescribeAll describe_should =
            (@it) =>
            {
                MyClass cls = new MyClass();

                @it("Describes the should operation");
                ObjectExtensions.Should(cls, @have => cls.Total);
                ObjectExtensions.Should(cls.Total, @be => 0);
                ObjectExtensions.Should(cls.Sum(1, 1), @be => 2);
                ObjectExtensions.Should(cls.Sub(1, 1), @be => 0);

                ObjectExtensions.Should(cls.Sum(1, 1), @be_close => 2, 0.5);
            };

        DescribeAll describe_times =
            (@it) =>
            {
                MyClass cls = new MyClass();

                @it("Describes the times operation");
                NumberExtensions.Times(10, () => { cls.Sum(1, 1); });
            };
    }
}
