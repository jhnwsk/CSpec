using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using CSpec.Shell.Display;
using CSpec.Extensions;
using System.IO;

namespace Test.Spec
{
    public class CSpecConsoleSpec : CSpecFacade<CSpecConsole>
    {
        private ConsoleFormatter formatter;
        private const string dummyMessage = "Hello World";

        public CSpecConsoleSpec()
        {
            formatter = new ConsoleFormatter();
            CSpecConsole console = new CSpecConsole(formatter);
            InitializeFacade(console);

            CreateOperations();
        }

        /*
         * As we cannot test this, we just do pragmatic testing, and check for unexpected uncatched exceptions.
         * And test if the color is defaulted on the console after each write.
         */

        private DescribeAll describe_write_info_custom;

        private void CreateOperations()
        {
            describe_write_info_custom =
            (@it, @do) =>
            {
                formatter.InfoColor.Foreground = ConsoleColor.Green;
                @it("Writes a info message to the console with custom color green");
                @it("The color should be then reset to its default state");
                @do.WriteInfo(dummyMessage);
                Console.ForegroundColor.Should(@be => ConsoleColor.Gray);
            };
        }

        DescribeAll describe_write_info =
            (@it, @do) =>
            {
                @it("Writes a info message to the console, that should be in a white (default) color");
                @it("The color should be then reset to its default state");
                @do.WriteInfo(dummyMessage);
                Console.ForegroundColor.Should(@be => ConsoleColor.Gray);
            };
    }
}
