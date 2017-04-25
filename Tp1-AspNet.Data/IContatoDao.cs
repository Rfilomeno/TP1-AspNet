using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_AspNet.Domain.Models;

namespace Tp1_AspNet.Data
{
    public interface IContatoDao
    {
        
        EntityContext _contexto { get; set; }

        Contato[] GetAll();
    }
}
