using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp1_AspNet.Data;
using Tp1_AspNet.Domain.Models;
using Tp1_AspNet.Presentation.Models;
using DevTrends.MvcDonutCaching;

namespace Tp1_AspNet.Presentation.Controllers
{
    public class HomeController : Controller
    {
        [DonutOutputCache(Duration = 30)]
        public ActionResult Index()
        {
            
                return View();
                                  
        }

        
        public ActionResult ListaComEmail()
        {

            if (TempData["contatos"] == null)
            {
                EntityContext contexto = new EntityContext();

                ContatoDao dao = new ContatoDao(contexto);

                Contato[] contatos = dao.GetAll();
                contatos = AdicionaContatosNoBancoSeNaoExistir(dao, contatos);



                List<ContatoViewModel> contatosVM = new List<ContatoViewModel>();
                foreach (var contato in contatos)
                {
                    contatosVM.Add(new ContatoViewModel()
                    {
                        Nome = contato.Nome,
                        Sobrenome = contato.Sobrenome,
                        Email = contato.Email,
                        Telefone = contato.Telefone,
                        Selecionado = false
                    });
                }

                TempData["contatos"] = contatosVM;
                TempData.Keep();
                return View(TempData["contatos"]);
            }
            else
            {
                TempData.Keep();
                return View(TempData["contatos"]);
            }



        }

        public ActionResult Seleciona(string nome, string actionqueestava)
        {
            IList<ContatoViewModel> contatosVM = new List<ContatoViewModel>();
            contatosVM = (List<ContatoViewModel>)TempData["contatos"];


            foreach (var item in contatosVM)
            {
                if (item.Nome == nome)
                {
                    if (item.Selecionado)
                    {
                        item.Selecionado = false;
                    }
                    else
                    {
                        item.Selecionado = true;
                    }
                    TempData.Clear();
                    TempData["contatos"] = contatosVM;
                    
                }
            }
            TempData.Keep();
            return RedirectToAction(actionqueestava);
            
        }

        [DonutOutputCache(Duration = 30)]
        public ActionResult Lista2()
        {
            return View();            
        }
        public ActionResult ListaComTelefone()
        {
            if (TempData["contatos"] == null)
            {
                EntityContext contexto = new EntityContext();

                ContatoDao dao = new ContatoDao(contexto);

                Contato[] contatos = dao.GetAll();
                contatos = AdicionaContatosNoBancoSeNaoExistir(dao, contatos);



                List<ContatoViewModel> contatosVM = new List<ContatoViewModel>();
                foreach (var contato in contatos)
                {
                    contatosVM.Add(new ContatoViewModel()
                    {
                        Nome = contato.Nome,
                        Sobrenome = contato.Sobrenome,
                        Email = contato.Email,
                        Telefone = contato.Telefone,
                        Selecionado = false
                    });
                }

                TempData["contatos"] = contatosVM;
                TempData.Keep();
                return View(TempData["contatos"]);
            }
            else
            {
                TempData.Keep();
                return View(TempData["contatos"]);
            }
        }

        private static Contato[] AdicionaContatosNoBancoSeNaoExistir(ContatoDao dao, Contato[] contatos)
        {
            if (contatos.Count() == 0)
            {
                Contato contato1 = new Contato("Rodrigo", "Filomeno", 987536007, "rodrigo.filomeno@al.infnet.edu.br");
                Contato contato2 = new Contato("Filipe", "Vasconcelos", 12354678, "Filipe.Vasconcelos@al.infnet.edu.br");
                Contato contato3 = new Contato("Victor Hugo", "Dias", 456789456, "Victor.Dias@al.infnet.edu.br");
                Contato contato4 = new Contato("Munir", "Wanis", 789456123, "Munir.Wanis@al.infnet.edu.br");
                Contato contato5 = new Contato("Gabriel", "Ramos", 654987321, "Gabriel.Ramos@al.infnet.edu.br");
                dao.Salva(contato1);
                dao.Salva(contato2);
                dao.Salva(contato3);
                dao.Salva(contato4);
                dao.Salva(contato5);

                contatos = dao.GetAll();
            }

            return contatos;
        }

    }
}