using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPMIPROSTENIKDYNEJDE
{
    /// <summary>
    /// Represents a database manager for handling Orders.
    /// </summary>
    internal class OrderDatabase : Database<Order>
    {
        /// <summary>
        /// Deletes the specified order from the database.
        /// </summary>
        /// <param name="order">The order to be deleted.</param>
        public void Delete(Order order)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to delete the order based on its ID
                string query = "DELETE FROM Order WHERE ID = " + order.ID;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Executes the SQL command to delete the order
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>A collection of all orders in the database.</returns>
        public IEnumerable<Order> GetAll()
        {
            List<Order> orderList = new List<Order>();

            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to select all orders
                string query = "SELECT ID, deliveryTime, produtName, vipCustomer, customerID FROM Order";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieves order data from the database and creates Order objects
                            int id = reader.GetInt32(0);
                            string deliveryTime = reader.GetString(1);
                            string produtName = reader.GetString(2);
                            bool vipCustomer = reader.GetBoolean(3);
                            int customerID = reader.GetInt32(4);

                            Order objednavka = new Order(id, deliveryTime, produtName, vipCustomer, customerID);
                            orderList.Add(objednavka);
                        }
                    }
                }
            }

            return orderList;
        }

        /// <summary>
        /// Retrieves an order from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The order corresponding to the specified ID, or null if not found.</returns>
        public Order GetByID(int id)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to select an order by ID
                string query = "SELECT ID, deliveryTime, produtName, vipCustomer, customerID FROM Order WHERE ID = " + id;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieves order data and creates an Order object
                            string deliveryTime = reader.GetString(1);
                            string produtName = reader.GetString(2);
                            bool vipCustomer = reader.GetBoolean(3);
                            int customerID = reader.GetInt32(4);
                            return new Order(id, deliveryTime, produtName, vipCustomer, customerID);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Saves the specified order to the database.
        /// </summary>
        /// <param name="order">The order to be saved.</param>
        public void Save(Order order)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to insert a new order into the database
                string query = "INSERT INTO Objednavka (CasDodani, NazevProduktu, VipZakaznik, Zakaznik_ID) VALUES " +
                    "(" + order.deliveryTime + order.productName + order.vipCustomer + order.customerID + ")";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Executes the SQL command to insert the order
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
