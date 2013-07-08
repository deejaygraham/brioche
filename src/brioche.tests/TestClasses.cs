
namespace brioche.tests
{
    public class SkeletonClass
    {
    }

    public abstract class SkeletonAbstractClass 
    { 
    }

    public interface IEmptyInteface 
    { 
    }

    public class ConcreteClassImplementingEmptyInterface : IEmptyInteface 
    { 
    }

    public class AlternativeConcreteClassImplementingEmptyInterface : IEmptyInteface 
    { 
    }

    public abstract class AbstractClassImplementingEmptyInterface : IEmptyInteface 
    { 
    }

    public class ClassWithSingleEmptyMethod
    {
        public void DoSomething()
        {
        }
    }

    public class ClassWithPublicConstructor 
    { 
        public ClassWithPublicConstructor() 
        { 
        } 
    }

    public class ClassWithProtectedConstructor
    {
        protected ClassWithProtectedConstructor()
        {
        }
    }
    
    public class ClassWithConstructorParameters
    {
        public ClassWithConstructorParameters(int p1, float p2)
        {
        }
    }
}
