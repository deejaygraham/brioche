using System;
using System.Reflection;

namespace brioche
{
    /// <summary>
    /// Attempts to resolve simple dependencies in object creation.
    /// </summary>
    public class ResolvingInstanceCreator : ICreateInstances
    {
        private IRegisterTypes _typeRegistry;

        /// <summary>
        /// Constructor taking type registry to do dependency resolution.
        /// </summary>
        /// <param name="registry"></param>
        public ResolvingInstanceCreator(IRegisterTypes registry)
        {
            this._typeRegistry = registry;
        }

        /// <summary>
        /// Create an object of the type required.
        /// </summary>
        /// <param name="instanceType"></param>
        /// <returns></returns>
        public object CreateInstance(Type instanceType)
        {
            ConstructorInfo info = instanceType.FindMostSpecificConstructor();

            if (info == null)
            {
                var creator = new SimpleInstanceCreator();
                return creator.CreateInstance(instanceType);
            }
            else
            {
                object[] args = CreateParametersFor(info);

                return info.Invoke(args);
            }
        }

        private object[] CreateParametersFor(ConstructorInfo info)
        {
            object[] args = new object[info.GetParameters().Length];

            int index = 0;

            foreach (ParameterInfo pi in info.GetParameters())
            {
                args[index++] = CreateArgument(pi);
            }

            return args;
        }

        private object CreateArgument(ParameterInfo pi)
        {
            object obj;

            Type parameterType = pi.ParameterType;

            var creator = new SimpleInstanceCreator();

            if (this._typeRegistry.Contains(parameterType))
            {
                Type concreteType = this._typeRegistry.Find(parameterType);
                obj = creator.CreateInstance(concreteType);
            }
            else
            {
                obj = creator.CreateInstance(parameterType);
            }

            return obj;
        }
    }
}
