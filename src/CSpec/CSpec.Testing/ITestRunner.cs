using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CSpec.Testing
{
    /// <summary>
    /// Test runner interface that can be used to create 
    /// new better test runners.
    /// </summary>
    public interface ITestRunner
    {
        /// <summary>
        /// Gets operations passed
        /// </summary>
        int Passed { get;}
        /// <summary>
        /// Gets operations failed
        /// </summary>
        int Failed { get; }

        /// <summary>
        /// Runs tests on an assembly, it is advides that all 
        /// descriptor types will be kept in seperate assembly.
        /// </summary>
        /// <param name="asm"></param>
        void RunTestOnAssembly(Assembly asm);

        /// <summary>
        /// Runs a single batch of tests on the designated object.
        /// </summary>
        /// <param name="objType">Type of the object to be tested</param>
        void RunTestOnType(Type objType);

        /// <summary>
        /// Event that's invoked before operation
        /// CSpecTestItem will be containing a name in this state.
        /// </summary>
        event Action<CSpecTestItem> BeforeOperation;
        /// <summary>
        /// Event that's invoked with operation
        /// CSpecTestItem will be containing a name and description in this state.
        /// </summary>
        event Action<CSpecTestItem> Operation;
        /// <summary>
        /// Event that's invoked after operation
        /// CSpecTestItem will be containing a name, description and result in this state.
        /// </summary>
        event Action<CSpecTestItem> AfterOperation;
    }
}
