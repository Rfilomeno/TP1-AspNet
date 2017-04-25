using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_AspNet.Domain.Models;

namespace Tp1_AspNet.Data
{
    public class EntityContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
    }
}
