using System;
using System.Collections.Generic;

namespace brioche
{
    /// <summary>
    /// TypeRegistry is used to associate a specific type with a general type.
    /// </summary>
    public class SimpleTypeRegistry : IRegisterTypes
    {
        /// <summary>
        /// Initialize an empty registry
        /// </summary>
        public SimpleTypeRegistry()
        {
            this.TypeMapping = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Test whether the registry contains an instances of this general type
        /// </summary>
        /// <param name="generalType"></param>
        /// <returns></returns>
        public bool Contains(Type generalType)
        {
            return this.TypeMapping.ContainsKey(generalType);
        }

        /// <summary>
        /// Register a specific type with a general type or interface. Cannot register an
        /// abstract type as a specific type
        /// </summary>
        /// <param name="general"></param>
        /// <param name="specific"></param>
        public void Register(Type general, Type specific)
        {
            if (specific.IsInterface)
            {
                throw new ArgumentException(string.Format("Cannot register interface type {0}", specific.FullName));
            }

            if (specific.IsAbstract)
            {
                throw new ArgumentException(string.Format("Cannot register abstract type {0}", specific.FullName));
            }

            if (!general.IsAssignableFrom(specific))
            {
                throw new ArgumentException(string.Format("Cannot register unrelated types {0}, {1}", general.FullName, specific.FullName));
            }

            if (this.TypeMapping.ContainsKey(general))
            {
                this.TypeMapping[general] = specific;
            }
            else
            {
                this.TypeMapping.Add(general, specific);
            }
        }

        /// <summary>
        /// Find the registered instance given the general type
        /// </summary>
        /// <param name="general"></param>
        /// <returns></returns>
        public Type Find(Type general)
        {
            if (this.TypeMapping.ContainsKey(general))
                return this.TypeMapping[general];

            throw new TypeNotRegisteredException(string.Format("Type \'{0}\' not registered", general.ToString()));
        }

        private Dictionary<Type, Type> TypeMapping
        {
            get;
            set;
        }
    }
}

