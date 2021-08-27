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

        public IActionResult FTS(String busca)
        {
            ViewData["busca"] = busca;

            if (!String.IsNullOrEmpty(busca))
            {
                return View(_exemplar.FTS(busca));
            }

            return View();
        }
    }
}
