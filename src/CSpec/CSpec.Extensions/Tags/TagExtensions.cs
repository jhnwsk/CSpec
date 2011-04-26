using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSpec.Exceptions;
using CSpec.Resources;
using System.Collections;
using System.Reflection;

namespace CSpec.Extensions.Tags
{
    /// <summary>
    /// TagExtensions are used by the should operator extension
    /// </summary>
    /// <remarks>
    /// This class can be used to have stron typed operators,
    /// rather then meta kywords that are only validated in runtime.
    /// </remarks>
    public static class TagExtensions
    {
        /// <summary>
        /// Used to indicate that a type or return type should be equal to something.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Be<T, N>(this T obj, N value)
        {
            if (obj.Equals(value))
                return obj;

            throw new CSpecException(ExceptionMessages.Key + " @be");
        }

        /// <summary>
        /// Used to indicate that a type or return type should be not equal to something.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T NotBe<T, N>(this T obj, N value)
        {
            if (!obj.Equals(value))
                return obj;

            throw new CSpecException(ExceptionMessages.Key + " @be");
        }

        /// <summary>
        ///  Used on booleans and object.
        ///  When it's called on objects properties it does null checks on those properties.
        ///  When called on booleans it check if some return type or value is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Have<T, N>(this T obj, N value)
        {
            Type returnType = value.GetType();

            if (returnType == typeof(bool))
            {
                object val = value;
                if ((bool)val)
                    return obj;
                else
                    throw new CSpecException(ExceptionMessages.Key + " @have");
            }
            else
            {
                if (value != null)
                    return obj;
            }

            throw new CSpecException(ExceptionMessages.Key + " @have");
        }

        /// <summary>
        ///  Used on collections and arrays to check for a specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Contain<T, N>(this T obj, N value)
        {
            Type objType = obj.GetType();

            if (objType.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                IEnumerable itterator = (IEnumerable)obj;

                foreach (var item in itterator)
                {
                    if (value.Equals(item))
                        return obj;
                }

                throw new CSpecException(ExceptionMessages.Key + " @contain");
            }

            throw new CSpecException(ExceptionMessages.Key + " @contain");
        }

        /// <summary>
        /// Used on collections  and arrays to check for a specified item, but using
        /// reflection checking that is, by matching members not references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ReflectionContain<T, N>(this T obj, N value)
        {
            Type objType = obj.GetType();

            if (objType.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                IEnumerable itterator = (IEnumerable)obj;

                foreach (var item in itterator)
                {
                    if (ReflectionEqual(item, value))
                        return obj;
                }

                throw new CSpecException(ExceptionMessages.Key + " @rcontain");
            }

            throw new CSpecException(ExceptionMessages.Key + " @rcontain");
        }

        /// <summary>
        /// Used on numbers, represents the logical rule actual == expected +/- delta
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static T BeClose<T, N>(this T obj, N value, N delta)
        {
            //This could be problematic
            //when dealing with floating points that need to be very precise
            //we should convert to a numeric type that we use, but that would require number class
            //implementation, but if this will do us problems then such class will be created.
            decimal number = 0;
            decimal numberDelta = 0;
            decimal actual = 0;

            if (IsNumeric(obj) && IsNumeric(value))
            {
                number = Convert.ToDecimal(value);
                numberDelta = Convert.ToDecimal(delta);
                actual = Convert.ToDecimal(obj);

                if (Math.Abs(actual - number) < numberDelta)
                {
                    return obj;
                }

                throw new CSpecException(ExceptionMessages.Key + " @be_close");

            }

            throw new CSpecException(ExceptionMessages.Key + " @be_close");
        }

        private static bool ReflectionEqual(object actual, object expected)
        {
            Type actualType = actual.GetType();
            Type expectedType = expected.GetType();

            if (actualType.Name == expectedType.Name)
            {
                BindingFlags flags = (System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Static
                    | System.Reflection.BindingFlags.Instance);

                MemberInfo[] actualMembers = actualType.GetMembers(flags);
                MemberInfo[] expectedMembers = expectedType.GetMembers(flags);

                if (actualMembers.Length == expectedMembers.Length)
                {
                    for (int i = 0; i < actualMembers.Length; i++)
                    {
                        if (actualMembers[i].Name != expectedMembers[i].Name)
                            return false;
                        else if (actualMembers[i].MemberType != expectedMembers[i].MemberType)
                            return false;
                        else if (actualMembers[i].MetadataToken != expectedMembers[i].MetadataToken)
                            return false;
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tests if a object is numeric. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsNumeric(object value)
        {
            TypeCode code = Type.GetTypeCode(value.GetType());
            switch (code)
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }

            return false;
        }
    }
}
