namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int SC = 25;
            int LC = 35;
            double Tax = 6.0/100.0;


            Console.WriteLine("Number of small carpets: ");
            double nomSc = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Number of large carpets: ");
            double nomLc = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Price per small room: $25");

            Console.WriteLine("Price per large room: $35");

            double finalCostSc = nomSc * SC;
            double finalCostLC = nomLc * LC;

            double Cost = finalCostSc + finalCostLC;
            Console.WriteLine($"Cost: {Cost} ");

            double finalTax = Tax * Cost;
            Console.WriteLine($"Tax: {Tax * Cost} ");

            double TE = Cost + finalTax;
            Console.WriteLine($"Total estimate: {TE} ");
            Console.WriteLine("This estimate is valid for 30 days");







        }
    }
}
