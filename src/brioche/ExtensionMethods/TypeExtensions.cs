using System;
using System.Reflection;

namespace brioche
{
	/// <summary>
	/// Extension methods for Type queries
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Is the supplied type a concrete type ?
		/// </summary>
		/// <param name="testThisType"></param>
		/// <returns></returns>
		public static bool IsConcreteType(this Type testThisType)
		{
			return !testThisType.IsAbstract
				&& !testThisType.IsGenericTypeDefinition
				&& !testThisType.IsInterface;
		}

		/// <summary>
		/// Does the supplied type have a public constructor ?
		/// </summary>
		/// <param name="testThisType"></param>
		/// <returns></returns>
		public static bool HasPublicConstructor(this Type testThisType)
		{
			return testThisType.GetConstructors().Length > 0;
		}

        public static ConstructorInfo FindMostSpecificConstructor(this Type instanceType)
        {
            ConstructorInfo[] allConstructors = instanceType.GetConstructors();

            int ConstructorArgumentHighWater = -1;
            ConstructorInfo info = null;

            foreach (ConstructorInfo oneConstructor in allConstructors)
            {
                int thisSize = oneConstructor.GetParameters().Length;

                if (thisSize > ConstructorArgumentHighWater)
                {
                    info = oneConstructor;
                }
            }

            return info;
        }

    }
}
