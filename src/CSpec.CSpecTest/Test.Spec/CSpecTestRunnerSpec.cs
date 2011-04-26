using System;
using CSpec.Extensions;
using CSpec.Exceptions;
using CSpec.Testing;
using CSpec;
using Test.Common;
using System.Reflection;
using System.IO;

namespace Test.Spec
{
	public class CSpecTestRunnerSpec : CSpecFacade<CSpecTestRunner>
	{
        public CSpecTestRunnerSpec()
            : base(new CSpecTestRunner())
        {
            Should(@have => ObjSpec.Failed == 0);
            Should(@have => ObjSpec.Passed == 0);

            CreateOperations();
        }

        //MS aparently has a bug in the code.
        //without this nothing will work and the DESCRIBE ALL delegate will throw exception.
        //In mono it works perfect.
        private Action<string> dummy;
        private MyClassSpec myClassSpec;
        private DescribeAll run_on_type;

		protected override void BeforeOperation()
		{
            myClassSpec = new MyClassSpec();
		}

        /// <summary>
        /// Creates operations, that describe behaviour of this class.
        /// </summary>
        /// <remarks>
        /// This method is used for cases when we want o put external private objects
        /// in the operation itself, having operations initialized on the field level
        /// passing external types would be impossible.
        /// </remarks>
        private void CreateOperations()
        {
            run_on_type =
               (@it, @do) =>
               {
                   @it("Runs all of the operations contained in a type");
                   @do.RunTestOnType(myClassSpec.GetType());
                   @do.Passed.Should(@be => 3);
                   @do.Failed.Should(@be => 0);
               };
        }

	}
}
