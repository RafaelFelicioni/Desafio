using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Repository.Interfaces;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafioEmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public DesafioEmailController(IEmailRepository emailRepository) {
            _emailRepository = emailRepository;
        }
        
        [HttpPost("SalvarEmails", Name = "SalvarEmails")]
        public async Task<DTOResposta> SalvarEmails() {
            var dtoResposta = await _emailRepository.ObterEmailsESalvar();

            return dtoResposta;
        }

        [HttpGet("ObterEmailDB", Name = "ObterEmailDB")]
        public List<DTOEmail> ObterEmailsDesafioDB() {
            var dto = _emailRepository.ObterEmailsDB();
            if (dto.Count == 0) {
                dto.Add(new DTOEmail() {
                    Erros = "Não foram encontrados emails no banco"
                });
            }
            return dto;
        }
    }
}
