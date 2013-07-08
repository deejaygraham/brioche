using System;
using System.Collections.Generic;
using System.Linq;

namespace brioche
{

    /// <summary>
    /// Extension class used to discover concrete types in an app domain.
    /// </summary>
    public static class AppDomainExtensions
    {
        /// <summary>
        /// Return all interfaces found.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IEnumerable<Type> AllInterfaces(this AppDomain domain)
        {
            return domain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsInterface);
        }

        /// <summary>
        /// All interfaces with the namespace prefix.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="namespacePrefix"></param>
        /// <returns></returns>
        public static IEnumerable<Type> AllInterfaces(this AppDomain domain, string namespacePrefix)
        {
            return domain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsInterface && type.FullName.StartsWith(namespacePrefix, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Return all concretes types implementing a particular interface.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ConcreteTypesImplementing(this AppDomain domain, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Supplied type is not an interface", "interfaceType");
            }

            return domain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => interfaceType.IsAssignableFrom(type)
                                && type.IsConcreteType()
                                && type.HasPublicConstructor());
        }

        /// <summary>
        /// Return all concretes types implementing a particular interface and in a base namespace.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="domain"></param>
        /// <param name="namespacePrefix"></param>
        /// <returns></returns>
        public static IEnumerable<Type> ConcreteTypesImplementing(this AppDomain domain, Type interfaceType, string namespacePrefix)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Supplied type is not an interface", "interfaceType");
            }

            return domain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => interfaceType.IsAssignableFrom(type)
                                && type.IsConcreteType()
                                && type.FullName.StartsWith(namespacePrefix, StringComparison.OrdinalIgnoreCase)
                                && type.HasPublicConstructor());
        }
    }
}
