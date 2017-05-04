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
       [OutputCache(Duration = 1)]
        public ActionResult Index()
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
            if (actionqueestava == "Index")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ListaComTelefone");

            }

        }

       [OutputCache(Duration = 1)]
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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