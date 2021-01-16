using System.Threading.Tasks;

namespace Flush.BlazorUtils
{
    /// <summary>
    /// Interop interface for accessing Window.localStorage.
    /// </summary>
    public interface ILocalStorage
    {
        /// <summary>
        /// Gets an object from local storage asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the deserialised object./typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The deserialised object.</returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Places an object in to local storage asynchonously.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialise.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The object.</param>
        void SetAsync<T>(string key, T value);
    }
}
