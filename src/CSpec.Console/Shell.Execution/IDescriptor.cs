using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Shell.Execution
{
    /// <summary>
    /// Describes the information that's needed to run action and commands by their
    /// key, and provides a description what implementers do.
    /// </summary>
    public interface IDescriptor
    {
        string Key { get; }
        string Description { get; }
    }

}
