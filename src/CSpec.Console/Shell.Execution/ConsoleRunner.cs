using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Shell.Display;
using System.Reflection;

namespace CSpec.Shell.Execution
{
    /// <summary>
    /// Console runner class, used as a primary application
    /// start point.
    /// </summary>
    public class ConsoleRunner
    {
        private ConsoleFormatter formatter;
        private CSpecConsole console;
        private List<IAction> actions;

        public ConsoleRunner()
        {
            formatter = new ConsoleFormatter();
            console = new CSpecConsole(formatter);

            InitializeActions();
        }

        //TODO: add action parsing code.

        /// <summary>
        /// Runs specified Action on the console.
        /// </summary>
        /// <param name="args">console arguments</param>
        public void Run(string[] args)
        {
            if (args == null || args.Length == 0)
                DisplayHelp();
            else
            {
                try
                {
                    string actionKey = args[0];

                    if (actionKey.ToUpper() == "help".ToUpper())
                        DisplayHelp();

                    foreach (var action in actions)
                    {
                        //Match actions
                        if (action.Key.ToUpper() == actionKey.ToUpper())
                        {
                            action.Execute(args);
                        }
                    }
                }
                catch (Exception ex)
                {
                    console.WriteError(ex.Message);
                }
            }
        }

        private void DisplayHelp()
        {
            foreach (var action in actions)
            {
                action.DisplayInterface();
            }
        }

        /// <summary>
        /// Adds actions provided by the console app.
        /// </summary>
        private void InitializeActions()
        {
            actions = new List<IAction>();
            actions.Add(new TestRunnerAction());
        }
    }
}
