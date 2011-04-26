using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Shell.Display;

namespace CSpec.Shell.Execution
{
    /// <summary>
    /// Describes an additional attribute for action that will need to be performend if present.
    /// </summary>
    public interface ICommand : IDescriptor
    {
        /// <summary>
        /// Executes the specifid command.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="actionParams"></param>
        void Execute(CSpecConsole console, params object[] actionParams);
    }
}
