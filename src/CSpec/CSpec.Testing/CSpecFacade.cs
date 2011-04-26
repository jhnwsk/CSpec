using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CSpec.Extensions;

namespace CSpec.Testing
{
    /// <summary>
    /// CSpec Testing Facade.
    /// This a base testing class every (non static) object that want's to be tested
    /// should inherit from this class.
    /// 
    /// "Should" methods are for testing the initial state of newly created
    /// object, for other methods a descibe deletate should be used with
    /// extension methods.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class CSpecFacade<TClass> : CSpecFacadeBase
    {
        /// <summary>
        /// Gets the described object.
        /// </summary>
        protected TClass ObjSpec { get; private set; }

		/// <summary>
		/// Base class, you need to call it to initialize
		/// the facade. 
		/// </summary>
		/// <param name="objSpec">
		///  <see cref="TClass"/>
		/// </param>
        protected CSpecFacade(TClass objSpec)
        {
            InitializeFacade(objSpec);
        }

        protected CSpecFacade()
        { }

        /// <summary>
        /// Initializes a facade
        /// The reason why children can acces this class is that sometimes
        /// building a constructor of objSpec can be problematic and very very complex
        /// and require hundreds of objects to finaly get the proper params and their states
        /// so this method is available for such case.
        /// Why not make setter of ObjSpec public?
        /// because this would not be noticible that this is thing that we need to set in order to
        /// initialize facade and besides by doing it in a method we give it gravity so this is an 
        /// indicator that we do it if we really must.
        /// </summary>
        /// <param name="objSpec"></param>
        protected void InitializeFacade(TClass objSpec)
        {
            this.ObjSpec = objSpec;
        }

        /// <summary>
        /// Used to describe the initial state of the object after it's been created.
        /// </summary>
        /// <typeparam name="N"></typeparam>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected TClass Should<N>(Expression<Func<TClass,N>> operation)
        {  
            return ObjectExtensions.Should(ObjSpec, operation);
        }
		
        /// <summary>
        /// Describes the behavior of the object (it's methods) using the attribte pattern.
        /// </summary>
        /// <param name="objSpec"></param>
        public delegate void Describe(TClass objSpec);
        /// <summary>
        /// Describes the behavior of the object (it's methods) using the fluent pattern.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="objSpec"></param>
        public delegate void DescribeAll(Action<string> description, TClass objSpec);
    }
}
