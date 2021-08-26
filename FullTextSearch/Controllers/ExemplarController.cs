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
        public IActionResult Index(string busca)
        {
            ViewData["busca"] = busca;

            List<Exemplar> listaExemplar = new List<Exemplar>();

            //listaExemplar = _exemplar.GetAllExemplar().ToList();

            //return View(listaExemplar);

            if (!String.IsNullOrEmpty(busca))
            {
                listaExemplar = _exemplar.busca(busca).ToList();

                return View(listaExemplar);

            }
            else
            {
                listaExemplar = _exemplar.GetAllExemplar().ToList();
                return View(listaExemplar.First());
            }
        }
        
        public IActionResult Search(String busca)
        {
            ViewData["busca"] = busca;
            //ViewData["Message"] = "Search Page";

            if (!String.IsNullOrEmpty(busca))
            {
                return View(_exemplar.busca(busca));
            }

            return View();
        }
    }
}
