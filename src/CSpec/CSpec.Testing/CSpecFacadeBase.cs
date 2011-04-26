using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Testing
{
    /// <summary>
    /// Base facade class that contains virtual operations like before and end.
    /// </summary>
    public class CSpecFacadeBase
    {
        /// <summary>
        /// This method will be executed before each operation run.
        /// </summary>
        protected virtual void BeforeOperation()
        { }

        /// <summary>
        ///This method will be executd after each operation run. 
        /// </summary>
        protected virtual void AfterOperation()
        { }
    }
}
