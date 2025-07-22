using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Demo Exception Handling");
            //try
            //{
            //    //Taking two numbers from user to check division
            //    Console.Write("Enter first number: ");
            //    int num1 = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("Enter second number: ");
            //    int num2 = Convert.ToInt32(Console.ReadLine());
            //    int result = num1 / num2;
            //}
            //catch (Exception ex)
            //{
            //    //Handling exception if user enters invalid input
            //    Console.WriteLine("Invalid input: " + ex.Message);
            //}
            //finally
            //{
            //    //This block will always execute
            //    Console.WriteLine("Finally block executed.");
            //}

            //Step 1: We are creating an instance of OrderProcessor class
            OrderProcessor orderProcessor = new OrderProcessor();
            //Step 2: We are calling the PlaceOrder method with productId, Quantity and orderAmount
            orderProcessor.PlaceOrder("PS5", 2, 1000.00m);
            orderProcessor.PlaceOrder("Gaming PC", -1, 2000.00m);
            orderProcessor.PlaceOrder("Gaming PC", 2, 2000.00m);
            orderProcessor.PlaceOrder("Smart Phone", 1, 500.00m);
            Console.WriteLine();
        }
    }
}
