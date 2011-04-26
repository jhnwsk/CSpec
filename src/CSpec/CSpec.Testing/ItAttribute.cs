using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Testing
{
    /// <summary>
    /// It attribute, CSpec uses two conventions of describing objects, and operations
    /// this is more .NET oriented and sometimes can be more clear, both of those methods can
    /// be used in single class.
    /// </summary>
    [global::System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class ItAttribute : Attribute
    {
        public string Description { get; private set; }

        public ItAttribute(string description)
        {
            this.Description = description;
        }
    }
}
