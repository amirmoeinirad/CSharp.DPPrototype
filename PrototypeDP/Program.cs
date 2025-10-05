
// Amir Moeini Rad
// September 2025

// Main Concept: Prototype Design Pattern
// With help from Gemini AI.

// In this pattern, a fully initialized instance (the prototype) is cloned to create new objects,
// rather than instantiating new objects directly.
// This is particularly useful when object creation is resource-intensive or complex.


namespace PrototypeDP
{
    // 1. Prototype Interface (or abstract class)
    internal interface ICarPrototype
    {
        ICarPrototype Clone();
        void Drive();
    }


    //--------------------------------------------------------


    // 2. Concrete Prototype
    internal class Car : ICarPrototype
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        // Constructor
        public Car(string model, string color, int year)
        {
            Model = model;
            Color = color;
            Year = year;

            Console.WriteLine($"Car created: {Color} {Year} {Model}");
            
            // Imagine complex, expensive initialization here.
        }

        // Clone method for shallow copy
        public ICarPrototype Clone()
        {
            // For simplicity, we assume all fields are value types or strings (which are immutable).
            // If the Car had reference type fields (e.g., Engine object), a deep copy would be required.
            // Object.MemberwiseClone() creates a shallow copy of the current object.
            // A 'Shallow' copy means that if the object contains references to other objects,
            // only the references are copied, not the actual objects they point to.
            // A 'Deep' copy means that all objects are duplicated, creating independent copies.
            return (ICarPrototype)MemberwiseClone();
        }

        public void Drive()
        {
            Console.WriteLine($"Driving the {Color} {Year} {Model}.");
        }
    }

    
    //--------------------------------------------------------


    // 3. Client Code
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("The Prototype Design Pattern in C#.NET.");
            Console.WriteLine("---------------------------------------\n");


            // Create the initial prototype object (expensive operation)
            Console.WriteLine("Creating the Prototype...");
            Car originalCar = new Car("Mustang", "Red", 1969);

            // Clone the prototype instead of creating a new one from scratch
            Console.WriteLine("\nCloning the Prototype...");
            Car cloneCar1 = (Car)originalCar.Clone();
            cloneCar1.Color = "Blue";
            cloneCar1.Year = 1970;

            Car cloneCar2 = (Car)originalCar.Clone();
            cloneCar2.Color = "Black";
            cloneCar2.Model = "Camaro";

            Console.WriteLine("\nDriving the Cars...\n");
            originalCar.Drive();
            cloneCar1.Drive();
            cloneCar2.Drive();

            Console.WriteLine("\nVerification...\n");
            Console.WriteLine($"Original Car Model: {originalCar.Model}");
            Console.WriteLine($"Clone 1 Car Model: {cloneCar1.Model}");            
            Console.WriteLine($"Clone 2 Car Model: {cloneCar2.Model}");


            Console.WriteLine("\nDone.");
        }
    }
}
