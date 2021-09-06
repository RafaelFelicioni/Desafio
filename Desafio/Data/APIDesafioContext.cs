using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Data
{
    public class APIDesafioContext : DbContext
    {
        public DbSet<ModelEmail> Emails { get; set; } 
        public DbSet<ModelNomesAgrupados> Nomes { get; set; } 

        public APIDesafioContext(DbContextOptions<APIDesafioContext> opt) : base(opt)
        {

        }
    }
}
