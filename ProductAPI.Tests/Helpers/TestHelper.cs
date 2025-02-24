using Azure.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Tests.Helpers
{
    public static class TestHelper
    {
        //criando um objeto para executar chamadas para a API dos produtos.
        public static HttpClient CreateClient()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5134") // Define a porta manualmente
            });

            return client;
        }

        //serializando os dados para o formato JSon
        public static StringContent CreateContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        //método para ler e deserializar o retorno da API após a execução de uma chamada.
        public static T ReadResponse<T>(HttpResponseMessage message)
        {
            var result = JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
            return result;
        }

    }
}
