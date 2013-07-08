using Xunit;

namespace brioche.tests
{
    public class TypeExtensionsFacts
    {
        public class IsConcreteTypeMethod
        {
            [Fact]
            public void Returns_False_For_Interface()
            {
                var type = typeof(IEmptyInteface);

                Assert.False(type.IsConcreteType());
            }

            [Fact]
            public void Returns_False_For_Abstract_Class()
            {
                var type = typeof(SkeletonAbstractClass);

                Assert.False(type.IsConcreteType());
            }

            [Fact]
            public void Returns_True_For_Concrete_Class()
            {
                var type = typeof(ClassWithSingleEmptyMethod);

                Assert.True(type.IsConcreteType());
            }
        }

        public class HasPublicConstructorMethod
        {
            [Fact]
            public void Returns_True_For_Auto_Generated_Constructor()
            {
                Assert.True(typeof(ClassWithSingleEmptyMethod).HasPublicConstructor());
            }

            [Fact]
            public void Returns_True_Explicit_Constructor()
            {
                Assert.True(typeof(ClassWithPublicConstructor).HasPublicConstructor());
            }

            [Fact]
            public void Returns_False_Protected_Constructor()
            {
                Assert.False(typeof(ClassWithProtectedConstructor).HasPublicConstructor());
            }
        }
    }

}
