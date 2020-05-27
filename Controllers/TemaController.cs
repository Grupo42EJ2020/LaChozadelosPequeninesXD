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

        //Metodo para ver DETALLES de un registro
        public ActionResult Details(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        //Metodo para ELIMINAR un registro de la tabla
        public ActionResult Delete(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection datos)
        {
            repoTema.eliminarTema(id);
            return RedirectToAction("Index");
        }

        //Metodo para CREAR registro en la tabla
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tema datosTema)
        {
            repoTema.insertarTema(datosTema);
            return RedirectToAction("Index");
        }

        //Metodo para EDITAR registro de la tabla
        public ActionResult Edit(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Tema datosTema)
        {
            datosTema.IdTema = id;
            repoTema.actualizarTema(datosTema);
            return RedirectToAction("Index");
        }
    }
}
