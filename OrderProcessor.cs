using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Exception_Handling
{
    //Step 4: We are creating a custom exception for inventory check.
    public class InventoryCheckException : Exception
    {
        public InventoryCheckException(string message) : base(message)// Calling the base class constructor
        {
            Console.WriteLine("InventoryCheckException: " + message);
        }
    }
    internal class OrderProcessor
    {
        //An online Shopping application processes orders placed by customers.
        //During check out process, multiple operartions  payemnt, inventory check, order confirmation etc. are performed.
        //They may face following exceptions:
        //INvalid User input Exception
        // Payment Failure Exception
        // Inventory Check Exception/out od stock Exception
        //Null refernce Exception
        //File not found udirng logging or invoice generation
        //A s developer , you need to handle these exceptions gracefully to ensure a smooth user experience.

        //user Story based on above sceanrio :
        //A  User tries to place an order for a product. the system must :
        //Validate the Order amounut and ensure it is a valid number.
        //Check if the product is in stock.// user define exception: 
        //Process the payment and handle any payment failures.
        //Genrate invoices and save to file system.
        //return a success message or an error message to the user.

        //Step 1: We are creating a inventory data via collection Dictionary<string, int>
        private Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            { "Gaming PC", 100 },
            { "PS5", 0 }, // Out of stock
            { "Smart Phone", 5 }
        };
        //Step 2: We are creating a method to process orders with fields like product name, quantity, and order amount.
        public void PlaceOrder(string ProductId, int Quantity, decimal orderAmount)
        {
            try
            {
                // Step 3: Calling te method to validate the order amount.
                ValidateOrderAmount(orderAmount);

                // Step 4: Calling the method to check the inventory.
                CheckInventory(ProductId, Quantity);

                // Step 5: Calling the method to process the payment.
                ProcessPayment(orderAmount);

                // If all operations are successful, we can confirm the order.
                Console.WriteLine($"Order placed successfully for {Quantity} units of '{ProductId}' at amount {orderAmount:C}.");

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Input Error: " + ex.Message);
            }

            catch (InventoryCheckException ex)
            {
                Console.WriteLine("Inventory Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Payment Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                // This block will always execute, regardless of whether an exception occurred or not.
                Console.WriteLine("Order attempted logged at :" + DateTime.Now);
            }
        }
        //Step 3: We are creating a method to validate the order amount.
        private void ValidateOrderAmount(decimal orderAmount)
        {
            if (orderAmount <= 0)
            {
                throw new ArgumentException("Order amount must be greater than zero.");
            }
        }
        //Step 4: We are creating a method to check the inventory.
        private void CheckInventory(string productId, int quantity)
        {
            if (!inventory.ContainsKey(productId) || inventory[productId] < quantity)// here we are chekcing for productId and quantity
            {
                //Step 4: Throwing custom exception for inventory check
                throw new InventoryCheckException($"Product '{productId}' is out of stock or insufficient quantity available.");
            }
        }

        //Step 5: We are creating a method to process the payment.
        private void ProcessPayment(decimal orderAmount)
        {
            // Simulating payment processing
            if (orderAmount > 5000) // Simulating a payment failure for high amounts
            {
                throw new InvalidOperationException("Payment processing failed due to high order amount.");
            }
        }
    }
}
