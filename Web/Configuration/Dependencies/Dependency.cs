using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Autofac;

namespace Reload.Web.Configuration.Dependencies
{
	/// <summary>The dependency class.</summary>
	public class Dependency : IDependencyResolver
	{
		/// <summary>The dependency registry</summary>
		private readonly IContainer Registry;

		/// <summary>The constructor.</summary>
		/// <param name="container"></param>
		public Dependency(IContainer container)
		{
			this.Registry = container;
		}

		/// <summary>Returns the resolved service.</summary>
		/// <param name="serviceType"></param>
		public object GetService(Type serviceType)
		{
			if(!this.Registry.IsRegistered(serviceType)) { return null; }

			return this.Registry.Resolve(serviceType);
		}

		/// <summary>Returns the resolved services.</summary>
		/// <param name="serviceType"></param>
		public IEnumerable<object> GetServices(Type serviceType)
		{
			Type enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);

			object instance = this.Registry.Resolve(enumerableServiceType);

			return ((IEnumerable) instance).Cast<object>();
		}
	}
}