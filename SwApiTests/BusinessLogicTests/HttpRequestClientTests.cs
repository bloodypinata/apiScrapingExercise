using Xunit;
using SwApi.BusinessLogic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace SwApiTests.BusinessLogicTests
{
    public class HttpRequestClientTests
    {
        [Fact]
        public void NullClientThrowsException()
        {
            var path = "api/starships/?format=json";

            var ex = Assert.ThrowsAsync<Exception>(() => HttpRequestClient.GetShipAsync(path, null));
        }

        [Fact]
        public void InvalidUrlThrowsException()
        {
            var client = new HttpClient();
            var url = "https://INVALIDurl.co";
            var path = "api/starships/?format=json";

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

            var ex = Assert.ThrowsAsync<Exception>(() => HttpRequestClient.GetShipAsync(path, client));
        }
        
    }
}
