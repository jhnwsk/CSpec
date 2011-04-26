using System;
using System.Collections.Generic;
using System.Text;
using CSpec.Testing;
using Test.Common;

namespace Test.Spec
{
    public class CSpecFacadeSpec :  CSpecFacade<CSpecFacade<MyClass>>
    {
        //As almost all members are protected we cannot have this operations 

        public CSpecFacadeSpec()
            : base(null)
        {

        }
    }
}
