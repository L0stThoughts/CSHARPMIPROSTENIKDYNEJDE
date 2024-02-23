namespace CSHARPMIPROSTENIKDYNEJDE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerDatabase customerData = new CustomerDatabase();
            OrderDatabase orderData = new OrderDatabase();

            // Prints out all the customers
            Console.WriteLine("Customers: ");
            foreach (var customer in customerData.GetAll())
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("\n");

            // Prints out all the customers
            Console.WriteLine("Orders: ");
            foreach (var order in orderData.GetAll())
            {
                Console.WriteLine(order);
            }


            // does not seem to work...
        }
    }
}
