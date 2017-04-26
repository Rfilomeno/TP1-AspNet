using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_AspNet.Domain.Models
{
    public class Contato
    {
        public int id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public Contato()
        {

        }
        public Contato(string nome, string sobrenome, int telefone, string email)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.Email = email;

        }
    }
}
