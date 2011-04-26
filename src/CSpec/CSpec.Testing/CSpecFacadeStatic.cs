using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;

namespace CSpec.Testing
{
    /// <summary>
    /// CSpec Testing Facade Static.
    /// This a base testing class every (static) object that want's to be tested
    /// should inherit from this class.
    /// </summary>
    public class CSpecFacadeStatic : CSpecFacadeBase
    {
        /// <summary>
        /// Describes the behavior of the object (it's methods) using the attribute pattern.
        /// </summary>
        public delegate void Describe();

        /// <summary>
        /// Describes the behavior of the object (it's methods) using the fluent pattern.
        /// </summary>
        public delegate void DescribeAll(Action<string> description);

    }
}
