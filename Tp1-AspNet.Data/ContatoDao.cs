using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_AspNet.Domain.Models;

namespace Tp1_AspNet.Data
{
    public class ContatoDao : IContatoDao
    {
        public EntityContext _contexto { get; set; }

        public ContatoDao(EntityContext contexto)
        {
            this._contexto = contexto;
        }

        public Contato[] GetAll()
        {
            Contato[] contatos = _contexto.Contatos.ToArray();

            return contatos;
        }

        public void Salva(Contato contato)
        {
            _contexto.Contatos.Add(contato);
            _contexto.SaveChanges();
        }
    }
}
