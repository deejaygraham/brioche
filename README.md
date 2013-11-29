brioche
=======

Example Inversion of Control library.

To use it, create a type registry object and an instance creation object:

````
var typeRegistry = new SimpleTypeRegistry();
var instanceCreator = new ResolvingInstanceCreator(typeRegistry);
````

Then set up the type container depending on whether you want to auto-discover all the composable types we can find:

````
var container = new AutoTypeContainer("MyNamespace", typeRegistry, instanceCreator);
````

or add types manually:
 
````
var container = new TypeContainer(typeRegistry, instanceCreator);
````

and register the types you will need:

````
DependencyInjection.Container.Register<ISpeak, Cat>();
DependencyInjection.Container.Register<ISpeak, Dog>();
DependencyInjection.Container.Register<ISpeak, Parrot>();
DependencyInjection.Container.Register<ISpeak, Hydra>();
````

Then set the IoC container:

````
DependencyInjection.Container = container;
````				

Then when you need to create a type:

````
var speaker = DependencyInjection.Container.Resolve<ISpeak>();
speaker.Speak();
````
