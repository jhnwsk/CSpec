using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace CSpec.Extensions
{
    /// <summary>
    /// Contains extension methods that are number scoped.
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Invokes the dynamic operation X times where X is the number that is extended.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="operation">Action that does not take any arguments</param>
        /// <returns></returns>
        public static int Times(this int obj, Action operation)
        {
            for (int i = 0; i < obj; i++)
            {
                operation();
            }

            return obj;
        }
    }
}
