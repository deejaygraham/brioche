using System;
using System.Collections.Generic;
using System.Linq;

namespace brioche
{
	/// <summary>
	/// Attempts to scan for classes and interfaces in the current app domain 
	/// and register them appropriately.
	/// </summary>
    public class AutoTypeDiscoverer
    {
		/// <summary>
		/// Initialize with blank namespace filtering.
		/// </summary>
		/// <param name="container"></param>
		public AutoTypeDiscoverer(IContainTypes container)
			: this(container, string.Empty)
		{
		}

		/// <summary>
		/// Restrict to a particular root namespace.
		/// </summary>
		/// <param name="container"></param>
		/// <param name="namespaceName"></param>
		public AutoTypeDiscoverer(IContainTypes container, string namespaceName)
		{
			this.Container = container;
			this.NamespaceName = namespaceName;
		}

		/// <summary>
		/// The namespace filter
		/// </summary>
		public string NamespaceName
		{
			get;
			set;
		}

		private IContainTypes Container
		{
			get;
			set;
		}

		/// <summary>
		/// Scans the current app domain and register.
		/// </summary>
		public void Scan()
		{
			var domain = AppDomain.CurrentDomain;
			var allInterfaces = domain.AllInterfaces();

			foreach (Type interfaceType in allInterfaces)
			{
				IEnumerable<Type> foundTypes = null;

				if (string.IsNullOrEmpty(this.NamespaceName))
				{
					foundTypes = domain.ConcreteTypesImplementing(interfaceType);
				}
				else
				{
					foundTypes = domain.ConcreteTypesImplementing(interfaceType, this.NamespaceName);
				}

				if (foundTypes.Any())
				{
					this.RegisterTypesImplementingInterface(interfaceType, foundTypes);
				}
			}
															
		}

		private void RegisterTypesImplementingInterface(Type interfaceType, IEnumerable<Type> concreteTypes)
		{
			// looking for a type matching the interface without the first I
			string candidateName = interfaceType.Name.TrimStart('I');

			bool found = false;

			foreach (Type concreteType in concreteTypes)
			{
				// IFoo == Foo or ConcreteFoo ends with Foo
				if (candidateName == concreteType.Name
					|| concreteType.Name.EndsWith(candidateName, StringComparison.OrdinalIgnoreCase))
				{
					this.Container.Register(interfaceType, concreteType);
					found = true;
				}
			}

			// 2nd pass if nothing found so far - go with the first one in the list...
			if (!found)
			{
				Type firstType = concreteTypes.First();
				this.Container.Register(interfaceType, firstType);
			}
		}
	}
}
