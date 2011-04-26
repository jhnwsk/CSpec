using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using System.Reflection;
using CSpec.Shell.Display;
using Shell.Resources;

namespace CSpec.Shell.Execution
{
    /// <summary>
    /// Action that runs operations conatined in an asembly
    /// Additional Attributes (Commands):
    ///  -a AllCommand - displays detailed information about operation curently performed.
    /// </summary>
    public class TestRunnerAction : IAction
    {
        private ITestRunner runner;
        private ConsoleFormatter formatter;
        private CSpecConsole console; 

        /// <summary>
        /// Default constructor that initializes the console and it's formatters, as
        /// well as a list of commands used.
        /// </summary>
        public TestRunnerAction()
        {
            runner = new CSpecTestRunner();
            formatter = new ConsoleFormatter();
            console = new CSpecConsole(formatter);

            Commands = new List<ICommand>() { new Commands.RunnerAllCommand() };
        }

        /// <summary>
        /// Gets List of commands used by this action
        /// </summary>
        public List<ICommand> Commands { get; private set; }

        /// <summary>
        /// Executes the action with specified console parameters
        /// </summary>
        /// <param name="args">application args</param>
        public void Execute(string[] args)
        {
            if (args[1] == null || args[1] == string.Empty)
            {
                console.WriteError("No arguments");
                DisplayInterface();
            }
            else
            {
                for (int i = 2; i < args.Length; i++)
                {
                    var command = Commands.Where(x => x.Key.ToUpper() == args[i].ToUpper()).FirstOrDefault();

                    if (command != null)
                    {
                        command.Execute(console, runner);
                    }
                }

                Assembly asm = Assembly.LoadFile(args[1]);
                runner.RunTestOnAssembly(asm);

                console.WriteInfo("\n Tests passed: " + runner.Passed + "/" + (runner.Failed + runner.Passed));
            }
        }

        /// <summary>
        /// Displays the help interface to the console.
        /// </summary>
        public void DisplayInterface()
        {
            console.WriteInfo(this.Key + " : " + this.Description);
            foreach (var cmd in Commands)
                console.WriteInfo(cmd.Key + " : " + cmd.Description);
        }

        public string Key
        {
            get { return "runner"; }
        }

        public string Description
        {
            get { return ActionMessages.TestRunner; }
        }
    }
}
