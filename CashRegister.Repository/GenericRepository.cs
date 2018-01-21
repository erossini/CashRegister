using CashRegister.Library.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CashRegister.Repository
{
    public class GenericRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List of Good.</returns>
        public List<T> ReadFile(string filepath)
        {
            List<T> items;

            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                items = (List<T>)serializer.Deserialize(file, typeof(List<T>));
            }

            return items;
        }

        /// <summary>
        /// Saves the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The goods.</param>
        /// <returns><c>true</c> if the function wrote the file, <c>false</c> otherwise.</returns>
        public bool SaveFile(string filepath, List<T> items)
        {
            bool rtn = false;

            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
                rtn = true;
            }

            return rtn;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if the function wrote the file, <c>false</c> otherwise.</returns>
        public bool SaveFile(string filepath, T items)
        {
            bool rtn = false;

            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
                rtn = true;
            }

            return rtn;
        }
    }
}
