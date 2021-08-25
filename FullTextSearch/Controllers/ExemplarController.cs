using FullTextSearch.Entity;
using FullTextSearch.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTextSearch.Controllers
{
    public class ExemplarController : Controller
    {
        private readonly IExemplarDAL _exemplar;
        public ExemplarController(IExemplarDAL exemplar)
        {
            _exemplar = exemplar;
        }
        public IActionResult Index()
        {
            List<Exemplar> listaExemplar = new List<Exemplar>();

            listaExemplar = _exemplar.GetAllExemplar().ToList();

            return View(listaExemplar);
        }
    }
}
