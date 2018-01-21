using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CashRegister.ConsoleApp.Data
{
    public static class FileData
    {
        public static void CreateDataDirectory()
        {
            string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string directoryData = Path.Combine(localPath, "Data");
            if (!Directory.Exists(directoryData))
                Directory.CreateDirectory(directoryData);
        }

        /// <summary>
        /// Gets the goods file.
        /// </summary>
        /// <value>The goods file.</value>
        public static string GoodsFile(string timestamp = "")
        {
            string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filename = Path.Combine(localPath, $"Data\\Goods{timestamp}.json");
            return filename;
        }

        /// <summary>
        /// Gets the basket file.
        /// </summary>
        /// <value>The basket file.</value>
        public static string BasketFile(string timestamp)
        {
                string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filename = Path.Combine(localPath, $"Data\\Basket{timestamp}.json");
                return filename;
        }

        /// <summary>
        /// Baskets the details file.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>System.String.</returns>
        public static string BasketDetailsFile(string timestamp)
        {
            string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filename = Path.Combine(localPath, $"Data\\BasketDetails{timestamp}.json");
            return filename;
        }

        /// <summary>
        /// Gets the basket history file.
        /// </summary>
        /// <value>The basket history file.</value>
        public static string BasketHistoryFile(string timestamp)
        {
                string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filename = Path.Combine(localPath, $"Data\\BasketHistory{timestamp}.json");
                return filename;
        }
    }
}
