using System;

namespace EFDemo
{
    public class Program
    {
        static readonly MyDealershipContext context = new MyDealershipContext();

        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var vehicles = context.Inventories.ToList();

            foreach(var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Year} {vehicle.Make} {vehicle.Model} {vehicle.Price}");
            }
            
        }

        
    }


}