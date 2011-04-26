using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Testing;
using CSpec.Shell.Display;

namespace Test.Spec
{
    public class ConsoleFormatterSpec : CSpecFacade<ConsoleFormatter>
    {
        public ConsoleFormatterSpec()
            : base(new ConsoleFormatter())
        {
            Should(@have => ObjSpec.DescriptionColor);
            Should(@have => ObjSpec.ErrorResultColor);
            Should(@have => ObjSpec.InfoColor);
            Should(@have => ObjSpec.NameColor);
            Should(@have => ObjSpec.Separator);
            Should(@have => ObjSpec.SuccessResultColor);
        }
    }
}
