using System;
using Xunit;

namespace brioche.tests
{
    public class SimpleInstanceCreatorTests
    {
        public class TheCreateInstanceMethod
        {
            [Fact]
            public void Can_Create_Simple_Types()
            {
                ICreateInstances creator = new SimpleInstanceCreator();

                Assert.Equal(0, (Int32)creator.CreateInstance(typeof(Int32)));
            }

            [Fact]
            public void Can_Create_Via_Default_Constructor()
            {
                ICreateInstances creator = new SimpleInstanceCreator();

                Assert.NotNull((SkeletonClass)creator.CreateInstance(typeof(SkeletonClass)));
            }

            [Fact]
            public void Can_Create_Via_Explicit_Constructor()
            {
                ICreateInstances creator = new SimpleInstanceCreator();

                Assert.NotNull((ClassWithPublicConstructor)creator.CreateInstance(typeof(ClassWithPublicConstructor)));
            }

            [Fact]
            public void Cannot_Create_With_No_Default_Constructor()
            {
                ICreateInstances creator = new SimpleInstanceCreator();

                Assert.Throws<MissingMethodException>(() =>
                    creator.CreateInstance(typeof(ClassWithConstructorParameters))
                    );
            }

        }

    }
}
