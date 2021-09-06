using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class ModelEmail
    {
        [Key]
        public int IdEmail { get; set; }
        public string Email { get; set; }
    }
}
