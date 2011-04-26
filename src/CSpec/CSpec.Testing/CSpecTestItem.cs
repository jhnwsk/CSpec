using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Testing
{
    /// <summary>
    /// Represents a descriptor class for tests. 
    /// </summary>
    public class CSpecTestItem
    {
        /// <summary>
        /// Gets/Sets test name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets/Sets test results
        /// </summary>
        public string Results { get; set; }
        /// <summary>
        /// Gets/Sets test description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Determines if test succeeded 
        /// </summary>
        public bool TestSucceed { get; set; }
    }
}
