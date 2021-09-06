using Desafio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository.Interfaces
{
    public interface INomesRepository
    {
        ValueTask<DTOResposta> ObterNomesESalvar();
        List<DTONomes> ObterNomesDB();
    }
}
