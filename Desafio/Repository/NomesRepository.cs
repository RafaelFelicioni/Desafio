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
    public class NomesRepository : ObterTodosDadosAPIExterna, INomesRepository
    {
        public APIDesafioContext _apiDesafioContext { get; set; }

        public NomesRepository(APIDesafioContext aPIDesafioContext) {
            _apiDesafioContext = aPIDesafioContext;
        }

        public async ValueTask<DTOResposta> ObterNomesESalvar() {
            var ret = new DTOResposta();
            var Dados = await ObterDTOAPIExterna();
            var nomesParaSalvar = new List<ModelNomesAgrupados>();
            if (Dados.Count > 0) {
                var datas = Dados.Select(t => t.CriadoEm.ToShortDateString());
                var nomesPorDataString = "";
                var tblNomesRet = _apiDesafioContext.Nomes.ToList();
                var datasDB = tblNomesRet.Select(t => t.CriadoEm);
                foreach (var item in datas.Distinct()) {
                    var nomesPorDataLista = Dados.Where(t => t.CriadoEm.ToShortDateString() == item).Select(t => t.Nome);
                    nomesPorDataString = string.Join(",", nomesPorDataLista);
                    nomesParaSalvar.Add(new ModelNomesAgrupados() {
                        NomesAgrupadosPorData = nomesPorDataString,
                        CriadoEm = item
                    });
                }
                if (tblNomesRet.Count > 0) {
                    nomesParaSalvar = nomesParaSalvar.Where(t => !datasDB.Contains(t.CriadoEm)).ToList();
                }
                if (nomesParaSalvar.Count > 0) {
                    foreach (var item in nomesParaSalvar) {
                        _apiDesafioContext.Nomes.Add(item);
                        _apiDesafioContext.SaveChanges();
                    }
                    ret.Resposta = "Nomes salvos com sucesso.";
                } else {
                    ret.Resposta = "Nomes já foram salvos no sistema.";
                }
                
            } else {
                ret.Resposta = "Nenhum nome foi encontrado para ser salvo.";
            }
            return ret;
        }

        public List<DTONomes> ObterNomesDB() {
            var ret = new List<DTONomes>();

            var tblNomeRet = _apiDesafioContext.Nomes.ToList();
            if (tblNomeRet.Count > 0) {
                tblNomeRet.ForEach(t => ret.Add(new DTONomes() {
                    Id = t.IdNomes,
                    CriadoEm = t.CriadoEm,
                    Nomes = t.NomesAgrupadosPorData
                }));
            } 
            return ret;
        }
    }
}

//var dadosTratados = new List<ModelEmail>();
//if (tblEmailRet.Count > 0) {
//    var listEmailApiExterna = new List<ModelEmail>();
//    Dados.ForEach(t => listEmailApiExterna.Add(new ModelEmail() {
//        Email = t.Email
//    }));
//    var listStringDB = tblEmailRet.Select(t => t.Email);
//    dadosTratados = listEmailApiExterna.Where(t => !listStringDB.Contains(t.Email)).ToList();
//} else {
//    Dados.ForEach(t => dadosTratados.Add(new ModelEmail() {
//        Email = t.Email
//    }));
//}
//var dadosParaSalvar = dadosTratados.Where(t => t.Email != null).ToList();
//if (dadosParaSalvar.Count > 0) {
//    foreach (var item in dadosParaSalvar) {
//        _apiDesafioContext.Emails.Add(item);
//        _apiDesafioContext.SaveChanges();
//    }
//    ret.Resposta = "Emails salvos com sucesso.";
//} else {
//    ret.Resposta = "Os emails ja foram inseridos no banco de dados.";
//}