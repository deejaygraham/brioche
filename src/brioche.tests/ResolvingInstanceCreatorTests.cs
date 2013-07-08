using System;
using Xunit;

namespace brioche.tests
{
    public class ResolvingInstanceCreatorTests
    {
        public class TheCreateInstanceMethod
        {
            [Fact]
            public void Can_Create_Simple_Types()
            {
                ICreateInstances creator = new ResolvingInstanceCreator(new SimpleTypeRegistry());

                Assert.Equal(0, (Int32)creator.CreateInstance(typeof(Int32)));
            }

            [Fact]
            public void Can_Create_Default_Constructor()
            {
                ICreateInstances creator = new ResolvingInstanceCreator(new SimpleTypeRegistry());

                Assert.NotNull((SkeletonClass)creator.CreateInstance(typeof(SkeletonClass)));
            }

            [Fact]
            public void Can_Create_Explicit_Constructor()
            {
                ICreateInstances creator = new ResolvingInstanceCreator(new SimpleTypeRegistry());

                Assert.NotNull((ClassWithPublicConstructor)creator.CreateInstance(typeof(ClassWithPublicConstructor)));
            }

            [Fact]
            public void Can_Create_Constructor_With_Builtin_Type_Parameters()
            {
                ICreateInstances creator = new ResolvingInstanceCreator(new SimpleTypeRegistry());

                Assert.NotNull((ClassWithConstructorParameters)creator.CreateInstance(typeof(ClassWithConstructorParameters)));
            }
        }
    }

}
