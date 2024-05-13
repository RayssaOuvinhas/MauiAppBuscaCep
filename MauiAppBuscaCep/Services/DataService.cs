using MauiAppBuscaCep.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;

namespace MauiAppBuscaCep.Services
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                string url = "https://cep.metoda.com.br/endereco/by-cep?cep=" + cep;

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return end;
        }

        public static async Task<List<Bairro>> GetBairrosByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://cep.metoda.com.br/bairro/by-cidade?id_cidade=" + id_cidade;

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_bairros;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(int uf)
        {
            List<Cidade> arr_cidade = new List<Cidade>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://cep.metoda.com.br/cidade/by-uf?uf=" + uf;

                HttpResponseMessage response = await client.GetAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidade = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_cidade;
        }
    }
}
