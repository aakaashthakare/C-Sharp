///<summary>
///Creational Pattern
///Separate the construction of a complex object from its representation so that the same construction process can create different representations
/// </summary>

/// When to use:
/// If you have optional dependencies: When you need to create objects with many optional parameters or complex configurations.
/// So, if your object has only a few constructor arguments, it makes no sense to use the builder pattern.
///

// Class diagram:
//+---------------------+        +---------------------+
//|      Person         |        |   PersonBuilder     |
//+---------------------+        +---------------------+
//| - FirstName: string |        | - person: Person    |
//| - LastName: string  |        +---------------------+
//| - Age: int          |        | + WithFirstName()   |
//| - Address: string   |        | + WithLastName()    |
//+---------------------+        | + WithAge()         |
//                               | + WithAddress()     |
//                               | + Build()           |
//                               +---------------------+

using System;
namespace Design_Patterns
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }

        public void sayHello()
        {
            Console.WriteLine("Hello " + FirstName);
        }
    }

    public class PersonBuilder
    {
        private Person _person = new Person();

        public PersonBuilder WithFirstName(string firstName)
        {
            _person.FirstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            _person.LastName = lastName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            _person.Age = age;
            return this;
        }

        public PersonBuilder WithAddress(string address)
        {
            _person.Address = address;
            return this;
        }

        public Person Build()
        {
            return _person;
        }
    }

}

