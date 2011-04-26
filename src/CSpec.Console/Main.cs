using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using CSpec.Shell.Display;
using CSpec.Shell.Execution;

namespace CSpec.Shell
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine("CSpec Test Runner: \n");

            ConsoleRunner runner = new ConsoleRunner();
            runner.Run(args);
		}
	}
}

