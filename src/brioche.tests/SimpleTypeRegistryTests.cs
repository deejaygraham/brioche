using System;
using Xunit;

namespace brioche.tests
{
    public class TypeRegistryFacts
    {
        public class TheContainsMethod
        {
            [Fact]
            public void Returns_False_When_Registry_Is_Empty()
            {
                var registry = new SimpleTypeRegistry();

                Assert.False(registry.Contains(typeof(System.String)));
            }

            [Fact]
            public void Returns_False_If_Type_Not_Registered()
            {
                var registry = new SimpleTypeRegistry();

                registry.Register(typeof(IEmptyInteface), typeof(ConcreteClassImplementingEmptyInterface));

                Assert.False(registry.Contains(typeof(ConcreteClassImplementingEmptyInterface)));
            }

            [Fact]
            public void Returns_True_If_Type_Registered()
            {
                var registry = new SimpleTypeRegistry();

                registry.Register(typeof(IEmptyInteface), typeof(ConcreteClassImplementingEmptyInterface));

                Assert.True(registry.Contains(typeof(IEmptyInteface)));
            }
        }

        public class TheFindMethod
        {
            [Fact]
            public void Throws_Exception_If_Type_Not_Found()
            {
                var registry = new SimpleTypeRegistry();

                Assert.Throws<TypeNotRegisteredException>(() =>
                    registry.Find(
                        typeof(int)));
            }

            [Fact]
            public void Returns_Specific_Type_When_Asked_For_General_Type()
            {
                var registry = new SimpleTypeRegistry();

                registry.Register(typeof(IEmptyInteface), typeof(ConcreteClassImplementingEmptyInterface));

                var concreteType = registry.Find(typeof(IEmptyInteface));

                Assert.Equal(typeof(ConcreteClassImplementingEmptyInterface), concreteType);
            }
        }

        public class TheRegisterMethod
        {
            [Fact]
            public void Registering_An_Interface_Throws_Exception()
            {
                var registry = new SimpleTypeRegistry();

                Assert.Throws<ArgumentException>(() =>
                    registry.Register(
                        typeof(ConcreteClassImplementingEmptyInterface),
                        typeof(IEmptyInteface)));
            }

            [Fact]
            public void Registering_An_Abstract_Class_Throws_Exception()
            {
                var registry = new SimpleTypeRegistry();

                Assert.Throws<ArgumentException>(() =>
                    registry.Register(
                        typeof(ConcreteClassImplementingEmptyInterface),
                        typeof(AbstractClassImplementingEmptyInterface)));
            }

            [Fact]
            public void Registering_Unrelated_Classes_Throws_Exception()
            {
                var registry = new SimpleTypeRegistry();

                Assert.Throws<ArgumentException>(() =>
                    registry.Register(
                        typeof(System.String),
                        typeof(AbstractClassImplementingEmptyInterface)));
            }

            [Fact]
            public void Replaces_Existing_Entry()
            {
                var registry = new SimpleTypeRegistry();

                registry.Register(typeof(IEmptyInteface), typeof(ConcreteClassImplementingEmptyInterface));
                Assert.Equal(typeof(ConcreteClassImplementingEmptyInterface), registry.Find(typeof(IEmptyInteface)));

                registry.Register(typeof(IEmptyInteface), typeof(AlternativeConcreteClassImplementingEmptyInterface));
                Assert.Equal(typeof(AlternativeConcreteClassImplementingEmptyInterface), registry.Find(typeof(IEmptyInteface)));
            }
        }
    }

}
