using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Shell.Execution
{
    /// <summary>
    /// Describes an action that is performed.
    /// </summary>
    public interface IAction : IDescriptor
    {
        /// <summary>
        /// Gets List of commands used by this action
        /// </summary>
        List<ICommand> Commands { get; }
        /// <summary>
        /// Executes the action with specified console parameters
        /// </summary>
        /// <param name="args">application args</param>
        void Execute(string[] args);
        /// <summary>
        /// Used to display help commands on the console.
        /// </summary>
        void DisplayInterface();
    }
}
