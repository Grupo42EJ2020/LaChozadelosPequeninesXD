using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class TemaController : Controller
    {
        //
        // GET: /Tema/

        RepositorioTema repoTema = new RepositorioTema();

        //Obtener la lista completa de Temas
        public ActionResult Index()
        {
            return View(repoTema.obtenerTemas());
        }

    }
}
