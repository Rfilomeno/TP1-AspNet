using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_AspNet.Presentation.Models
{
    public class ContatoViewModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public bool Selecionado { get; set; }
    }
}
