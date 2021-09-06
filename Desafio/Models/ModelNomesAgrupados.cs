using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class ModelNomesAgrupados
    {
        [Key]
        public int IdNomes { get; set; }
        public string CriadoEm { get; set; }
        public string NomesAgrupadosPorData { get; set; }
    }
}
