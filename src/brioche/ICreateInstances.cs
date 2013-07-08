using System;

namespace brioche
{
    /// <summary>
    /// Creates instances of objects from a type.
    /// </summary>
    public interface ICreateInstances
    {
        /// <summary>
        /// Create an instance.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        object CreateInstance(Type t);
    }
}
