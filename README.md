brioche
=======

Example Inversion of Control library.

To use it, create a type registry object and an instance creation object:

{% highlight csharp %}
var typeRegistry = new SimpleTypeRegistry();
var instanceCreator = new ResolvingInstanceCreator(typeRegistry);
{% endhighlight %}

Then set up the type container depending on whether you want to auto-discover all the composable types we can find:

{% highlight csharp %}
var container = new AutoTypeContainer("MyNamespace", typeRegistry, instanceCreator);
{% endhighlight %}

or add types manually:
 
{% highlight csharp %}
var container = new TypeContainer(typeRegistry, instanceCreator);
{% endhighlight %}

and register the types you will need:

{% highlight csharp %}
DependencyInjection.Container.Register<ISpeak, Cat>();
DependencyInjection.Container.Register<ISpeak, Dog>();
DependencyInjection.Container.Register<ISpeak, Parrot>();
DependencyInjection.Container.Register<ISpeak, Hydra>();
{% endhighlight %}

Then set the IoC container:

{% highlight csharp %}
DependencyInjection.Container = container;
{% endhighlight %}				

Then when you need to create a type:

{% highlight csharp %}
var speaker = DependencyInjection.Container.Resolve<ISpeak>();
speaker.Speak();
{% endhighlight %}
