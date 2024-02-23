using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPMIPROSTENIKDYNEJDE
{
        /// <summary>
        /// Represents a Singleton class responsible for managing database connections.
        /// </summary>
        internal class Singleton
        {
            private static SqlConnection conn = null;

            // Private constructor to prevent instantiation
            private Singleton()
            {
            }

            /// <summary>
            /// Gets a singleton instance of the SqlConnection object.
            /// </summary>
            /// <returns>A singleton instance of the SqlConnection object.</returns>
            public static SqlConnection GetInstance()
            {
                // If the connection is not yet established, create a new one
                if (conn == null)
                {
                    // Build connection string using settings from ConfigurationManager
                    SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.UserID = ReadSetting("Name");
                    consStringBuilder.DataSource = ReadSetting("DataSource");
                    consStringBuilder.ConnectTimeout = 30;

                    // Create and open the SqlConnection
                    conn = new SqlConnection(consStringBuilder.ConnectionString);
                    conn.Open();
                }
                return conn;
            }

            /// <summary>
            /// Closes the database connection if it's open and removes of it.
            /// </summary>
            public static void CloseConnection()
            {
                if (conn != null)
                {
                    // Close and dispose of the connection
                    conn.Close();
                    conn.Dispose();
                }
            }

            /// <summary>
            /// Reads a setting from the application configuration file.
            /// </summary>
            /// <param name="key">The key of the setting to read.</param>
            /// <returns>The value of the setting if found; otherwise, "Not Found".</returns>
            private static string ReadSetting(string key)
            {
                var appSettings = ConfigurationManager.AppSettings;
                // Read the setting value from the configuration file
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
        }
    }
