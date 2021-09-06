using Desafio.DadosDaAPIExterna;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Desafio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository
{
    public class EmailRepository : ObterTodosDadosAPIExterna, IEmailRepository
    {
        public APIDesafioContext _apiDesafioContext { get; set; }

        public EmailRepository(APIDesafioContext aPIDesafioContext) {
            _apiDesafioContext = aPIDesafioContext;
        }

        public async ValueTask<DTOResposta> ObterEmailsESalvar() {
            var ret = new DTOResposta();
            var Dados = await ObterDTOAPIExterna();
            var dadosFiltrados = Dados.Select(t => t.Email);
            if (Dados.Count > 0) {
                var tblEmailRet = _apiDesafioContext.Emails.ToList();
                var dadosTratados = new List<ModelEmail>();
                if (tblEmailRet.Count > 0) {
                    var listEmailApiExterna = new List<ModelEmail>();
                    Dados.ForEach(t => listEmailApiExterna.Add(new ModelEmail() {
                        Email = t.Email
                    }));
                    var listStringDB = tblEmailRet.Select(t => t.Email);
                    dadosTratados = listEmailApiExterna.Where(t => !listStringDB.Contains(t.Email)).ToList();
                } else {
                    Dados.ForEach(t => dadosTratados.Add(new ModelEmail() {
                        Email = t.Email
                    }));
                }
                var dadosParaSalvar = dadosTratados.Where(t => t.Email != null).ToList();
                if (dadosParaSalvar.Count > 0) {
                    foreach (var item in dadosParaSalvar) {
                        _apiDesafioContext.Emails.Add(item);
                        _apiDesafioContext.SaveChanges();
                    }
                    ret.Resposta = "Emails salvos com sucesso.";
                } else {
                    ret.Resposta = "Os emails ja foram inseridos no banco de dados.";
                }
            } else {
                ret.Resposta = "Nenhum email foi encontrado para ser salvo.";
            }
            return ret;
        }

        public List<DTOEmail> ObterEmailsDB() {
            var ret = new List<DTOEmail>();

            var tblEmailRet = _apiDesafioContext.Emails.ToList();
            if (tblEmailRet.Count > 0) {
                tblEmailRet.ForEach(t => ret.Add(new DTOEmail() {
                    Id = t.IdEmail,
                    Email = t.Email
                }));
            }
            return ret;
        }
    }
}
