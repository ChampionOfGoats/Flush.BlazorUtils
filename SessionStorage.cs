using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Flush.BlazorUtils
{
    public class SessionStorage : ISessionStorage
    {
        private static readonly string storeName = @"sessionStorage";
        private readonly ILogger<SessionStorage> logger;
        private readonly IJSRuntime jSRuntime;

        public SessionStorage(ILogger<SessionStorage> logger, IJSRuntime jSRuntime)
        {
            this.logger = logger;
            this.jSRuntime = jSRuntime;
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                await Task.CompletedTask;
                var exception = new ArgumentNullException(nameof(key));
                logger.LogError(exception, string.Empty);
                throw exception;
            }

            var value = await jSRuntime.InvokeAsync<T>($@"{storeName}.getItem", key);
            if (value is null)
            {
                await Task.CompletedTask;
                var exception = new ArgumentNullException(nameof(value));
                logger.LogError(exception, string.Empty);
                throw exception;
            }

            return value;
        }

        /// <inheritdoc/>
        public async void SetAsync<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                await Task.CompletedTask;
                var exception = new ArgumentNullException(nameof(key));
                logger.LogError(exception, string.Empty);
                throw exception;
            }

            if (value is null)
            {
                await Task.CompletedTask;
                var exception = new ArgumentNullException(nameof(value));
                logger.LogError(exception, string.Empty);
                throw exception;
            }

            try
            {
                var jsonValue = JsonSerializer.Serialize(value);
                await jSRuntime.InvokeVoidAsync($@"{storeName}.setItem", key, jsonValue);
            }
            catch (Exception exception)
            {
                await Task.CompletedTask;
                logger.LogError(exception, string.Empty);
                throw;
            }
        }
    }
}
