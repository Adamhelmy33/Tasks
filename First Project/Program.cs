using static System.Runtime.InteropServices.JavaScript.JSType;

namespace First_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your favorite number between 1 and 100:");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine($"No really!!, {age} is my favorite number too!");
        }
    }
}
