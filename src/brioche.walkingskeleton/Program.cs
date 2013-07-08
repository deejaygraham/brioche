using System;
using System.Collections.Generic;

namespace brioche.walkingskeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doSimpleInversion = true;

            if (args.Length > 0)
            {
                doSimpleInversion = !(string.Compare(args[0], "auto", StringComparison.CurrentCultureIgnoreCase) == 0);
            }

            if (doSimpleInversion)
            {
                var types = new SimpleTypeRegistry();
                var instances = new ResolvingInstanceCreator(types);

                var container = new TypeContainer(types, instances);
                DependencyInjection.Container = container;

                //DependencyInjection.Container.Register<ISpeak, Cat>();
                //DependencyInjection.Container.Register<ISpeak, Dog>();
                //DependencyInjection.Container.Register<ISpeak, Parrot>();
                DependencyInjection.Container.Register<ISpeak, Hydra>();
            }
            else
            {
                var types = new SimpleTypeRegistry();
                var instances = new ResolvingInstanceCreator(types);
                var container = new AutoTypeContainer("brioche.walkingskeleton", types, instances);

                DependencyInjection.Container = container;
            }

            try
            {
                var speaker = DependencyInjection.Container.Resolve<ISpeak>();

                speaker.Speak();
            }
            catch (MissingMethodException)
            {

            }

            Console.WriteLine("Demo complete, press a key to close window");
            Console.ReadKey();
        }
    }

    public interface ISpeak
    {
        void Speak();
    }

    public class Parrot : ISpeak
    {
        public void Speak()
        {
            Console.WriteLine("Awwk! Polly wanna cracker");
        }
    }

    public class Dog : ISpeak
    {
        public void Speak()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

    public class Cat : ISpeak
    {
        public void Speak()
        {
            Console.WriteLine("Me ow");
        }
    }

    /// <summary>
    /// Demonstrates the constructor resolution feature. 
    /// invrt will create instances of cat, dog and parrot
    /// to pass to constructor.
    /// </summary>
    public class Hydra : ISpeak
    {
        private List<ISpeak> _voices;

        public Hydra(Cat c, Dog d, Parrot p)
        {
            this._voices = new List<ISpeak>();
            this._voices.Add(c);
            this._voices.Add(d);
            this._voices.Add(p);
        }

        public void Speak()
        {
            Console.WriteLine("Hydra says...");

            foreach (ISpeak animal in this._voices)
            {
                animal.Speak();
            }
        }
    }

}
