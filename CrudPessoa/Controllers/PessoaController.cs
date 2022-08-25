using CrudPessoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudPessoa.Controllers
{
    public class PessoaController : Controller
    {
        bdcrudEntities bd = new bdcrudEntities();

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(bd.pessoa.ToList());
        }

        [HttpGet]
        public ActionResult Detalhe(int id)
        {
            pessoa p = bd.pessoa.ToList().Find(x => x.idpessoa == id);


            if (p != null)
            {
                return View(p);
            }
            else
            {
                return View();
            }


        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nome, long cpf, decimal renda )
        {
            pessoa p = new pessoa();
            p.nome = nome;
            p.cpf = cpf;
            p.renda = renda;

            bd.pessoa.Add(p);
            bd.SaveChanges();

            return View("Index", bd.pessoa.ToList());
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            pessoa p = bd.pessoa.ToList().Find(x => x.idpessoa == id);

            if (p != null)
            {
                return View(p);
            }
            else
            {
                return View(p);
            }

        }

        [HttpPost]
        public ActionResult Editar(int? id, string nome, long cpf, decimal renda)
        {
            pessoa p = bd.pessoa.ToList().Find(x => x.idpessoa == id);
            p.nome = nome;
            p.cpf = cpf;
            p.renda = renda;

            bd.SaveChanges();

            return View("Index", bd.pessoa.ToList());
        }

        [HttpGet]
        public ActionResult Excluir(int? id)
        {
            pessoa p = bd.pessoa.ToList().Find(x => x.idpessoa == id);

            if (p != null)
            {
                return View(p);
            }
            else
            {
                return View(p);
            }
            
        }

        [HttpPost]
        public ActionResult confirmeExcluir(int? id)
        {
            pessoa p = bd.pessoa.ToList().Find(x => x.idpessoa == id);

            bd.pessoa.Remove(p);
            bd.SaveChanges();

            return View("Index", bd.pessoa.ToList());


        }


    }
}