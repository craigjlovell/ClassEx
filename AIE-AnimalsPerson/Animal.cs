using System;

namespace AIE_AnimalsPerson
{

  

    class Animal
    {
        public string name = "";

        // Constructor
        public Animal(string name)
        {
            this.name = name;
        }

        public virtual void MakeNoise()
        {
            Console.WriteLine(name + ": makes noise");
        }
        public virtual void EatFood()
        {
            MakeNoise();
            Console.WriteLine("ate food");
        }
    }
    class Person
    {
       public void FeedAnimal(Animal animal)
        {
            animal.EatFood();
        }
    }

    class Dog : Animal
    {
        // Dog constructor
        public Dog() : base("Dog")
        {
        }
        public override void EatFood()
        {
            MakeNoise();
            Console.WriteLine(" YUM RAW MEAT");
        }
    }

    class Cat : Animal
    {
        // Cat constructor
        public Cat() : base("Cat")
        {
        }
    }

    class Bird : Animal
    {
        // Bird constructor
        public Bird() : base("Bird")
        {
        }
    }

    class Pig : Animal
    {
        // Bird constructor
        public Pig() : base("Pig")
        {
        }
        public override void MakeNoise()
        {
            Console.WriteLine(name + ": OINK OINK");
            // base.MakeNoise(); // calls the Animal.MakeNoise method
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //Dog dog = new Dog();
            //dog.MakeNoise(); // Outputs: Dog: Makes noise
            //
            //Cat cat = new Cat();
            //cat.MakeNoise(); // Outputs: Cat: Makes noise
            //
            //Bird bird = new Bird();
            //bird.MakeNoise(); // Outputs: Bird: Makes noise
            //
            //Pig pig = new Pig();
            //pig.MakeNoise();
            //
            //Animal someAnimal = new Animal("Crock");
            //someAnimal.MakeNoise();
            Dog dog = new Dog();
            Cat cat = new Cat();
            Bird bird = new Bird();
            Pig pig = new Pig();

            Person bob = new Person();
            bob.FeedAnimal(dog);    // What should be written to console?
            bob.FeedAnimal(cat);    // What should be written to console?
            bob.FeedAnimal(bird);
            bob.FeedAnimal(pig); // What should be written to console?
        }
    }
}
