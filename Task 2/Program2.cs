namespace Task_2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool programe = true;

            while (programe)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("C - Clear the list");
                Console.WriteLine("Q - Quit");

                Console.Write("\nEnter your choice: ");
                
                string letter = Console.ReadLine();

                if (letter == null || letter.Length == 0)
                { 
                    Console.WriteLine("Unknown selection, please try again");
                    continue;
                }
                else
                {
                    switch (letter)
                    {
                        case "P":
                        case "p":
                            if (numbers.Count == 0)
                                Console.WriteLine("[] - the list is empty");
                            else
                            {
                                Console.Write("[ ");
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                                Console.WriteLine("]");
                            }
                            break;

                        case "A":
                        case "a":
                            Console.WriteLine("Enter an integer: ");
                            int addNum = Convert.ToInt32(Console.ReadLine());
                            numbers.Add(addNum);
                            Console.WriteLine($"{addNum} added");
                            break;

                        case "M":
                        case "m":
                            if (numbers.Count == 0)
                                Console.WriteLine("Unable to calculate the mean - no data");
                            else
                            {
                                double sum = 0;
                                for (int i = 0;i < numbers.Count;i++)
                                {
                                    sum += numbers[i];
                                }
                                double mean = sum / numbers.Count;
                                Console.WriteLine($"The mean is {mean}");
                            }
                            break;

                        case "S":
                        case "s":
                            if (numbers.Count == 0)
                                Console.WriteLine("Unable to determine the smallest number - list is empty");
                            else
                            {
                                int smallest = numbers[0];
                                for(int i = 0;i <numbers.Count;i++)
                                {
                                    if (numbers[i] < smallest)
                                        smallest = numbers[i];
                                }
                                Console.WriteLine($"The smallest number is {smallest}");
                            }
                            break;

                        case "L":
                        case "l":
                            if (numbers.Count == 0)
                                Console.WriteLine("Unable to determine the largest  number - list is empty");
                            else
                            {
                                int largest = numbers[0];
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] > largest)
                                        largest = numbers[i];
                                }
                                Console.WriteLine($"The smallest number is {largest}");
                            }
                            break;

                        case "Q":
                        case "q":
                            Console.WriteLine("Goodbye");
                            programe = false;
                            break;

                        // to clear this program we can use (numbers.clear())
                        case "C":
                        case "c":
                            numbers.Clear();
                            Console.WriteLine("List Cleared");
                            break;

                        default:
                            Console.WriteLine("Unknown selection, please try again");
                            break;

                    }
                }
            }
        }
    }
}
