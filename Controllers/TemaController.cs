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
            //Realizar el delete del registro
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", id));

            BaseHelper.ejecutarSentencia("sp_Tema_Eliminar", CommandType.StoredProcedure, parametros);

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
            //Hacer el registro para agregar nueva Empresa
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", datosTema.Nombre));

            BaseHelper.ejecutarSentencia("sp_Tema_Insertar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index");
        }

        //Metodo para EDITAR registro de la tabla
        public ActionResult Edit(int id)
        {
            //Obtener la info del registro
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdTema", id));
            DataTable dtTema = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Tema datosTema = new Tema();
            if (dtTema.Rows.Count > 0) //si lo encontro
            {
                datosTema.IdTema = int.Parse(dtTema.Rows[0]["IdTema"].ToString());
                datosTema.Nombre = dtTema.Rows[0]["Nombre"].ToString();

                return View(datosTema);
            }
            else //no lo encontro
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Tema datosTema)
        {
            //relizar el update 
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", id));
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));

            BaseHelper.ejecutarConsulta("sp_Tema_Actualizar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index");
        }


    }
}
