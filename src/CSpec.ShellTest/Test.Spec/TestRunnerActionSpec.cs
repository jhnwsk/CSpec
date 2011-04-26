using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using CSpec.Extensions;
using CSpec.Shell.Execution;
using CSpec.Shell.Execution.Commands;

namespace Test.Spec
{
    public class TestRunnerActionSpec : CSpecFacade<TestRunnerAction>
    {
        public TestRunnerActionSpec()
            : base(new TestRunnerAction())
        {
            Should(@have => ObjSpec.Commands);
            Should(@have => ObjSpec.Commands.Count != 0);
            ObjSpec.Commands.Should(@rcontain => new RunnerAllCommand());
            ObjSpec.Commands.Count.Should(@be => 1);
        }

        DescribeAll describe_execute_null =
            (@it, @do) =>
            {
                @it("Calls the run command with null params, it should throw  exception, that's catched in the ConsoleRunner");
                try
                {
                    @do.Execute(null);
                }
                catch (Exception ex)
                {
                    //lets catch it ourselfs and print it.
                    @it(ex.Message);
                }
            };

        DescribeAll describe_execute_empty =
            (@it, @do) =>
            {
                @it("Calls the run command with no params, it should throw  exception, that's catched in the ConsoleRunner");
                try
                {
                    @do.Execute(new string[]{});
                }
                catch (Exception ex)
                {
                    @it(ex.Message);
                }
            };


    }
}
