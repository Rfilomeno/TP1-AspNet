using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp1_AspNet.Data;
using Tp1_AspNet.Domain.Models;
using Tp1_AspNet.Presentation.Models;

namespace Tp1_AspNet.Presentation.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            EntityContext contexto = new EntityContext();

            ContatoDao dao = new ContatoDao(contexto);

            Contato[] contatos = dao.GetAll();

            List<ContatoViewModel> contatosVM = new List<ContatoViewModel>();
            foreach (var contato in contatos)
            {
                contatosVM.Add(new ContatoViewModel()
                {
                    Nome = contato.Nome,
                    Sobrenome = contato.Sobrenome,
                    Email = contato.Email
                });
            }

            return View(contatosVM);
        }

        public ActionResult ListaComTelefone()
        {
            EntityContext contexto = new EntityContext();

            ContatoDao dao = new ContatoDao(contexto);

            Contato[] contatos = dao.GetAll();

            List<ContatoViewModel> contatosVM = new List<ContatoViewModel>();

            foreach (var contato in contatos)
            {
                contatosVM.Add(new ContatoViewModel()
                {
                    Nome = contato.Nome,
                    Sobrenome = contato.Sobrenome,
                    Telefone = contato.Telefone
                });
            }

            return View(contatosVM);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}