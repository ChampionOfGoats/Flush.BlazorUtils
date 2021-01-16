using System.Threading.Tasks;

namespace Flush.BlazorUtils
{
    /// <summary>
    /// Interop interface for accessing Window.sessionStorage.
    /// </summary>
    public interface ISessionStorage
    {
        /// <summary>
        /// Gets an object from session storage asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the deserialised object./typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The deserialised object.</returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Places an object in to session storage asynchonously.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialise.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The object.</param>
        void SetAsync<T>(string key, T value);
    }
}
