The other day I was having a discussion with one of my friends on how service locator and IoC containers are related and the Dependency injection best practices. Which let to another discussion
with some junior level developers on the internal workings of IoC containers. And this gave me an idea that writing a small IoC container might be a good exercise to explain these guys how IoC containers works internally. So this article talks briefly about a small IoC container that I created in an hours time for teaching the basics of IoC containers and how to implement one to some developers. I am putting this online so that someone might get benefited from this.

What is an IoC Container

To start the discussion, lets start with understanding what an IoC container is. An IoC container is a component that lets us register our Concrete class dependencies with our contracts i.e. interfaces so that for any given interface, the registered concrete class will be instantiated. This let the higher level modules specify their own concrete classes, register them and get them injected in the application for any given interface.

The above explanation is only the Dependency injection part of the IoC containers. An IoC container could also manage the life time of an object too. There are many full fledged IoC containers exists that provides a comprehensive solution for all the inversion of controls and object lifetime management needs. In no way the code in this article should be used for production applications. It is just a simple exercise to understand and take a sneak peek the inner workings of IoC containers.

Using the Code

Following list shows what has been implemented in this small application

1. Register interfaces with concrete types where for each Resolve request, a new instance will be returned.
2. Register interfaces with concrete types where for all Resolve request, a singleton instance will be returned.
3. Resolve the interfaces and retrieve the configured Concrete type for a given interface.

Here are few important that could be helpful before looking at the source code.

All the registrations are being done using code only. This code can be enhanced to read the dependencies from a config file but was not a part of this application scope.
This container is able to inject the nested dependencies provided all the dependencies have been registered before the Resolve call. I have tested up to 3 levels of nested dependencies but theoretically it should work up to N levels.
The code that has been written to support the Nested dependency injection is a little flaky and it works on an assumption that the dependent classes have constructor injection and have no default constructors. But since this was a code written for teaching and demonstration purpose, I left it like that(But it should not be used in production apps).
The test application for this is a console application that contains a lot of interfaces and classes with all the dependencies being registered and resolved in the Main function.

Now let us briefly look at the various components in the code.

IContainer - Interface that contains all the methods for our Container.
Container - Concrete class that implements the IContainer interface and encapsulates the inner working of registration and instance resolution.
RegistrationModel -  A simple model that keep the information about the type being registered and its life time.
InstanceCreationService - A service that takes care of instance creation from a given type. This class also takes care of nested dependencies and their injection.
SingletonCreationService - A service that keeps track of singleton instances and creates singleton instances on Resolve requests.

Point of interest

This small application is a result of an hour of code. The main idea of this application was to demonstrate how IoC containers work. This has been written as a teaching/learning exercise and thus the coding standards and best practices are not up to the mark. The code has been put in form of an article just to make it available to others(beginners mainly) so that they can also get a sneak peak on how IoC containers must be working. 
