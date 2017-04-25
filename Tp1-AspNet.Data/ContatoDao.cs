using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_AspNet.Domain.Models;

namespace Tp1_AspNet.Data
{
    public class ContatoDao
    {
        EntityContext contexto = new EntityContext();

        public Contato[] GetAll()
        {
            Contato[] contatos = contexto.Contatos.ToArray();

            return contatos;
        }
    }
}
