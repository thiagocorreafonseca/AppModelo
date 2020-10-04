using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TestCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TestCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Nome do Aluno",
                DataNascimento = DateTime.Now,
                Email = "emaildoaluno@email.com.br"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "email@email.com.br");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Eduardo");

            var aluno5 = new Aluno
            {
                Nome = "Aluno Teste",
                DataNascimento = DateTime.Now,
                Email = "emaildoaluno@email.com.br"
            };

            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Add(aluno5);
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}
