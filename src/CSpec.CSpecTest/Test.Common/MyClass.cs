using System;

namespace Test.Common
{
    /// <summary>
    /// Dummy class to provide testing type, for 
    /// CSpecFacade.
    /// </summary>
	public class MyClass
	{
		public MyClass ()
		{}
		
		public int Total {get; private set;}
		
		public int Sum(int a, int b)
		{
			int result = a + b;
			Total += result;
			return result;	
		}
		public int Sub(int a, int b)
		{
			int result = a - b;
			Total -= result;
			return result;
		}
	}
}

