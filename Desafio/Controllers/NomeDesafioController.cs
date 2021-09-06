using Desafio.DTO;
using Desafio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomeDesafioController : ControllerBase
    {
        private readonly INomesRepository _nomeRepository;

        public NomeDesafioController(INomesRepository nomeRepository) {
            _nomeRepository = nomeRepository;
        }

        [HttpPost("SalvarNomes", Name = "SalvarNomes")]
        public async Task<DTOResposta> SalvarNomesRetornadosDaAPI() {
            var dtoResposta = await _nomeRepository.ObterNomesESalvar();

            return dtoResposta;
        }

        [HttpGet("ObterNomesDesafioDB", Name = "ObterNomesDesafioDB")]
        public List<DTONomes> ObterNomesDesafioDB() {
            var dto = _nomeRepository.ObterNomesDB();
            if (dto.Count == 0) {
                dto.Add(new DTONomes() {
                    Erros = "Não foram encontrados nomes no banco"
                });
            }
            return dto;
        }
    }
}
