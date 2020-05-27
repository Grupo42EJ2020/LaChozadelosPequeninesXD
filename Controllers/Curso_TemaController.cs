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
    public class Curso_TemaController : Controller
    {
        //
        // GET: /Curso_Tema/

        RepositorioCurso_Tema repoCurso_Tema = new RepositorioCurso_Tema();

        public ActionResult Index()
        {
            return View(repoCurso_Tema.obtenerCurso_Temas());
        }

        public ActionResult Curso_Tema()
        {
            return View(repoCurso_Tema.obtenerCurso_Temas());
            //DataTable dtCurso_Tema;
            //dtCurso_Tema = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_CONSULTARTODO", CommandType.StoredProcedure);

            //List<Curso_Tema> lstCurso = new List<Curso_Tema>();

            ////convertir el DataTable a una lista de videos List<Video>
            //foreach (DataRow item in dtCurso_Tema.Rows)
            //{
            //    Curso_Tema Curso_TemaAux = new Curso_Tema();
            //    Curso_TemaAux.IdCT = Convert.ToInt32(item["IdCT"].ToString());
            //    Curso_TemaAux.IdCurso = Convert.ToInt32(item["IdCurso"].ToString());
            //    Curso_TemaAux.IdTema = Convert.ToInt32(item["IdTema"].ToString());
            //    lstCurso.Add(Curso_TemaAux);
            //}

            //return View(lstCurso);
        }

        public ActionResult Curso_TemaDelete(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));
            ////Datos del video para el usuario antes de borrarlo
            //DataTable dtCurso_Tema;
            //List<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@IdCT", id));
            //dtCurso_Tema = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_CONSULTARXID", CommandType.StoredProcedure, parametros);

            ////Convertir dtCurso en objeto
            //Curso_Tema datosCurso_Tema = new Curso_Tema();

            //if (dtCurso_Tema.Rows.Count > 0)//si lo encuentra
            //{
            //    datosCurso_Tema.IdCT = int.Parse(dtCurso_Tema.Rows[0]["IdCT"].ToString());
            //    datosCurso_Tema.IdCurso = int.Parse(dtCurso_Tema.Rows[0]["IdCurso"].ToString());
            //    datosCurso_Tema.IdTema = int.Parse(dtCurso_Tema.Rows[0]["IdTema"].ToString());


            //    return View(datosCurso_Tema);
            //}
            //else //si no lo encuentra
            //{
            //    return View("Error");
            //}
        }

        [HttpPost]
        public ActionResult Curso_TemaDelete(int id, FormCollection datos)
        {
            //RepositorioCurso_Tema repoCurso_Tema = new RepositorioCurso_Tema();
            //return View(repoCurso_Tema.eliminarCurso_Tema(IdCT));
            //realizar el delete del registro
            repoCurso_Tema.eliminarCurso_Tema(id);
            return RedirectToAction("Curso_Tema");
            //List<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@IdCT", id));

            //BaseHelper.ejecutarSentencia("SP_CURSO_TEMA_ELIMINAR", CommandType.StoredProcedure, parametros);

            //return RedirectToAction("Curso_Tema");
        }
        //----------------------DETALLES-------------------------------------------------
        public ActionResult Curso_TemaDetails(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));
        }
        //EDITAR-----------------------------------------------------------------------------
        public ActionResult Curso_TemaEdit(int id)
        {
            return View(repoCurso_Tema.obtenerCurso_Tema(id));

            //List<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@IdCT", id));
            //DataTable dtCurso_Tema = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_CONSULTARXID", CommandType.StoredProcedure, parametros);

            //Curso_Tema infoCurso_Tema = new Curso_Tema();

            //if (dtCurso_Tema.Rows.Count > 0) //lo encontro
            //{
            //    infoCurso_Tema.IdCT = int.Parse(dtCurso_Tema.Rows[0]["IdCT"].ToString());
            //    infoCurso_Tema.IdCurso = int.Parse(dtCurso_Tema.Rows[0]["IdCurso"].ToString());
            //    infoCurso_Tema.IdTema = int.Parse(dtCurso_Tema.Rows[0]["IdTema"].ToString());


            //    return View(infoCurso_Tema);
            //}
            //else
            //{  //no lo encontro 
            //    return View("Error");
            //}
        }

        [HttpPost]
        public ActionResult Curso_TemaEdit(int id, Curso_Tema datosCurso_Tema)
        {
            //RepositorioCurso_Tema repoCurso_Tema = new RepositorioCurso_Tema();
            //return View(repoCurso_Tema.actualizarCurso_Tema(Id));

            repoCurso_Tema.actualizarCurso_Tema(datosCurso_Tema);

            return RedirectToAction("Curso_Tema");

            //List<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@IdCT", id));
            //parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            //parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));


            //BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_ACTUALIZAR", CommandType.StoredProcedure, parametros);

            //return RedirectToAction("Curso_Tema");
        }
        //Metodo para CREAR registro en la tabla------------------------------------------------------------------------------
        public ActionResult Curso_TemaCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Curso_TemaCreate( Curso_Tema datosCurso_Tema)
        {
            //RepositorioCurso_Tema repoCurso_Tema = new RepositorioCurso_Tema();
            //return View(repoCurso_Tema.insertarCurso_Tema());
            repoCurso_Tema.insertarCurso_Tema(datosCurso_Tema);

            return RedirectToAction("Curso_Tema");
            //List<SqlParameter> parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            //parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));

            //BaseHelper.ejecutarSentencia("SP_CURSO_TEMA_INSERT", CommandType.StoredProcedure, parametros);

            //return RedirectToAction("Curso_Tema");
        }



    }
}
