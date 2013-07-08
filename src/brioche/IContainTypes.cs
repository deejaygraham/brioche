using System;

namespace brioche
{
    public interface IContainTypes
    {
        /// <summary>
        /// Register an implementation type should be returned when an abstract type is asked for.
        /// </summary>
        /// <param name="abstraction"></param>
        /// <param name="implementation"></param>
        void Register(Type abstraction, Type implementation);

        /// <summary>
        /// Register an implementation type should be returned when an abstract type is asked for.
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void Register<TAbstraction, TImplementation>() where TImplementation : TAbstraction;

        /// <summary>
        /// Instantiate an instance of the implementation type given the abstract type
        /// </summary>
        /// <param name="generalType"></param>
        /// <returns>An instance of a class implementing TAbstraction</returns>
        object Resolve(Type abstraction);

        /// <summary>
        /// Instantiate an instance of the implementation type given the abstract type
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <returns>An instance of a class implementing TAbstraction</returns>
        TAbstraction Resolve<TAbstraction>();
    }
}
