using Cliente_Base.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarCanal();
            EditarCanal(2);
            Console.ReadKey();
        }

        private async static void BuscarCanaisAsync()
        {
            var canais = new List<Canal>();
            var url = "http://localhost:2100/api/Values";
            var client = new HttpClient();

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode){
                var canaisJson = await response.Content.ReadAsStringAsync();
                canais = JsonConvert.DeserializeObject<List<Canal>>(canaisJson).ToList();
            }
        }

        private static void BuscarCanais()
        {
            var canais = new List<Canal>();
            var url = "http://localhost:2100/api/Values";
            var client = new HttpClient();

            var response = client.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var canaisJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                canais = JsonConvert.DeserializeObject<List<Canal>>(canaisJson).ToList();
            }
        }

        private async static void AdicionarCanalAsync()
        {
            var url = "http://localhost:2100/api/Values";
            var client = new HttpClient();

            var canal = new Canal()
            {
                Nome = "Rede Grobo"
            };

            var response = await client.PostAsJsonAsync(url, canal);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Inserido com sucesso!");
            }
        }

        private static void AdicionarCanal()
        {            
            var url = "http://localhost:2100/api/Values";
            var client = new HttpClient();

            var canal = new Canal()
            {
                Nome = "Rede Grobo"
            };

            var response = client.PostAsJsonAsync(url,canal).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Inserido com sucesso!");
            }
        }    

        private async static void RemoverCanalAsync(int id)
        {
            var url = "http://localhost:2100/api/Values/";
            var client = new HttpClient();

            var response = await client.DeleteAsync(url+id);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Removido com sucesso");
            }
        }

        private static void RemoverCanal(int id)
        {
            var url = "http://localhost:2100/api/Values/";
            var client = new HttpClient();

            var response = client.DeleteAsync(url + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Removido com sucesso");
            }
        }

        private static void EditarCanal(int id)
        {
            
            var url = "http://localhost:2100/api/Values/"+id;
            var client = new HttpClient();

            var canal = new Canal()
            {
                Nome = "Rede Record"
            };

            var response = client.PutAsJsonAsync<Canal>(url, canal).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Alterado com sucesso!");
            }
        }

    }
}
