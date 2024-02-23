using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSHARPMIPROSTENIKDYNEJDE
{
    /// <summary>
    /// Represents a database manager for handling Customer objects.
    /// </summary>
    internal class CustomerDatabase : Database<Customer>
    {
        /// <summary>
        /// Deletes the specified customer from the database.
        /// </summary>
        /// <param name="customer">The customer to be deleted.</param>
        public void Delete(Customer customer)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to delete the customer based on its ID
                string query = "DELETE FROM Customer WHERE ID = " + customer.ID;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Executes the SQL command to delete the customer
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all customers from the database.
        /// </summary>
        /// <returns>A collection of all customers in the database.</returns>
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();

            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to select all customers
                string query = "SELECT ID, Name, Email FROM Customer";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieves customer data from the database and creates Customer objects
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);

                            Customer customer = new Customer(id, name, email);
                            customerList.Add(customer);
                        }
                    }
                }
            }

            return customerList;
        }

        /// <summary>
        /// Retrieves a customer from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer corresponding to the specified ID, or null if not found.</returns>
        public Customer GetByID(int id)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to select a customer by ID
                string query = "SELECT ID, Name, Email FROM Customer WHERE ID = " + id;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieves customer data and creates a Customer object
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            return new Customer(id, name, email);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Saves the specified customer to the database.
        /// </summary>
        /// <param name="customer">The customer to be saved.</param>
        public void Save(Customer customer)
        {
            // Establishes a connection to the database using a Singleton pattern
            using (SqlConnection conn = Singleton.GetInstance())
            {
                // Constructs the SQL query to insert a new customer into the database
                string query = "INSERT INTO Zakaznik (Name, Email) VALUES (" + customer.name + customer.email + ")";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Executes the SQL command to insert the customer
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}