using Desafio.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Desafio.DadosDaAPIExterna
{
    public class ObterTodosDadosAPIExterna
    {
        public async Task<List<DTORetornoAPIExterna>> ObterDTOAPIExterna() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var ret = await client.GetStringAsync("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
            var models = JsonConvert.DeserializeObject<List<DTODadosAPIExterna>>(ret);
            List<DTORetornoAPIExterna> dtoRetornoAPIExterna = new List<DTORetornoAPIExterna>();
            models.ForEach(f => dtoRetornoAPIExterna.Add(new DTORetornoAPIExterna() {
                Avatar = f.avatar,
                CriadoEm = f.createdAt,
                Email = f.mail,
                Id = int.Parse(f.id),
                Nome = f.name
            }));
            return dtoRetornoAPIExterna;
        }
    }
}
