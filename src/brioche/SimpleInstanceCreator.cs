using System;

namespace brioche
{
    /// <summary>
    /// Simplest possible object creation.
    /// </summary>
    public class SimpleInstanceCreator : ICreateInstances
    {
        /// <summary>
        /// Create an instance of a type.
        /// </summary>
        /// <param name="instanceType"></param>
        /// <returns></returns>
        public object CreateInstance(Type instanceType)
        {
            return Activator.CreateInstance(instanceType);
        }
    }
}
