using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Exceptions
{
    [global::System.Serializable]
    public class CSpecException : System.Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CSpecException() { }
        public CSpecException(string message) : base(message) { }
        public CSpecException(string message, System.Exception inner) : base(message, inner) { }
        protected CSpecException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
