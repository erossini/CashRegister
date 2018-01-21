using System.Collections.Generic;

namespace CashRegister.Library.Interfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List&lt;T&gt;.</returns>
        List<T> ReadFile(string filepath);

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SaveFile(string filepath, List<T> items);
    }
}