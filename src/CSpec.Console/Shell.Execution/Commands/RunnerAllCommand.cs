using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using CSpec.Shell.Display;
using Shell.Resources;

namespace CSpec.Shell.Execution.Commands
{
    /// <summary>
    /// Displays detailed information about the operations.
    /// </summary>
    public class RunnerAllCommand : ICommand
    {
        public string Key
        {
            get { return "-a"; }
        }

        public string Description
        {
            get { return CommandMessages.RunnerAll; }
        }

        /// <summary>
        /// Executes the command.
        /// Hooks all runner events to the console to display all possible information
        /// from the runner.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="actionParams"></param>
        public void Execute(CSpecConsole console, params object[] actionParams)
        {
            if (actionParams[0] is ITestRunner)
            {
                ITestRunner runner = (ITestRunner)actionParams[0];

                runner.BeforeOperation += x => console.WriteTestName(x);
                runner.Operation += x => console.WriteTestDescription(x);
                runner.AfterOperation += x => console.WriteTestResult(x);
            }       
        }
    }
}
