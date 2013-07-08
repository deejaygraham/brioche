
using System;

namespace brioche
{
    /// <summary>
    /// Container for types requiring explicit registration.
    /// </summary>
    public class TypeContainer : IContainTypes
    {
        private readonly IRegisterTypes typeRegistry;
        private readonly ICreateInstances instanceCreator;

        /// <summary>
        /// Constructor specifying type registry and instance creator.
        /// </summary>
        public TypeContainer(IRegisterTypes types, ICreateInstances instances)
        {
            this.typeRegistry = types ?? new SimpleTypeRegistry();
            this.instanceCreator = instances ?? new SimpleInstanceCreator();
        }

        /// <summary>
        /// Register a specific implementation to provide when asked for the general type.
        /// </summary>
        /// <param name="abstraction"></param>
        /// <param name="implementation"></param>
        public void Register(Type abstraction, Type implementation)
        {
            this.typeRegistry.Register(abstraction, implementation);
        }

        /// <summary>
        /// Create an object of the type asked for (or a subclass, implementation of interface etc.)
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public void Register<TAbstraction, TImplementation>() where TImplementation : TAbstraction
        {
            this.Register(typeof(TAbstraction), typeof(TImplementation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abstraction"></param>
        /// <returns></returns>
        public object Resolve(Type abstraction)
        {
            Type specificType = this.typeRegistry.Find(abstraction);

            return this.instanceCreator.CreateInstance(specificType);
        }

        /// <summary>
        /// Create an object of the type asked for (or a subclass, implementation of interface etc.)
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <returns></returns>
        public TAbstraction Resolve<TAbstraction>()
        {
            return (TAbstraction)this.Resolve(typeof(TAbstraction));
        }
    }
}
