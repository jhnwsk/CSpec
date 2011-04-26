using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using CSpec.Shell.Display;
using CSpec.Shell.Execution;
using CSpec.Extensions;
using System.Reflection;
using System.IO;

namespace Test.Spec
{
    public class ConsoleRunnerSpec : CSpecFacade<ConsoleRunner>
    {
        public ConsoleRunnerSpec()
            : base(new ConsoleRunner())
        {
        }

        private Action<string> dummy;

        /*
         * As we cannot test this, we just do pragmatic testing, and check for unexpected uncatched exceptions.
         */
        DescribeAll describe_run =
            (@it, @do) =>
            {
                @it("Runs the console with arguments, for null args it should write help");
                @do.Run(null);
            };

        DescribeAll describe_run_help =
            (@it, @do) =>
            {
                @it("Runs the console with arguments, for help it should write help");
                @do.Run(new string[] { "help" });
            };

        DescribeAll describe_run_assembly_all =
            (@it, @do) =>
            {
                @it("Runs the console with runner arguments, it should write out full verbose test results for -a");
                @do.Run(new string[] { "runner", Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\CSpec.CSpecTest.dll", "-a" });
            };

        DescribeAll describe_run_assembly_bad_path =
            (@it, @do) =>
            {
                @it("Runs the console with runner arguments, it should fail for non abosolute path, but with a proper message");
                @do.Run(new string[] { "runner", "CSpec.CSpecTest.dll", "-a" });
                Console.ForegroundColor.Should(@be => ConsoleColor.Gray);
            };
    }
}
