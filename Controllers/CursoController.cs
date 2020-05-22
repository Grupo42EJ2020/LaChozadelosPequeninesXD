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
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso()
        {
            DataTable dtCurso;
            dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarTodo", CommandType.StoredProcedure);

            List<Curso> lstCurso = new List<Curso>();

            //convertir el DataTable a una lista de videos List<Video>
            foreach (DataRow item in dtCurso.Rows)
            {
                Curso CursoAux = new Curso();
                CursoAux.IdCurso = Convert.ToInt32(item["IdCurso"].ToString());
                CursoAux.Descripcion = item["Descripcion"].ToString();
                CursoAux.IdEmpleado = Convert.ToInt32(item["IdEmpleado"].ToString());
                lstCurso.Add(CursoAux);
            }

            return View(lstCurso);
        }

        public ActionResult CursoDelete(int id)
        {
            //Datos del video para el usuario antes de borrarlo
            DataTable dtCurso;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));
            dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            //Convertir dtCurso en objeto
            Curso datosCurso = new Curso();

            if (dtCurso.Rows.Count > 0)//si lo encuentra
            {
                datosCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                datosCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                datosCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());


                return View(datosCurso);
            }
            else //si no lo encuentra
            {
                return View("Error");
            }
        }
        
        [HttpPost]
        public ActionResult CursoDelete(int id, FormCollection datos)
        {
            //realizar el delete del registro
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));

            BaseHelper.ejecutarSentencia("sp_Curso_Eliminar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Curso");
        }

        public ActionResult CursoDetails(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));
            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso infoCurso = new Curso();

            if (dtCurso.Rows.Count > 0) //lo encontro
            {
                infoCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                infoCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                infoCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                

                return View(infoCurso);
            }
            else
            {  //no lo encontro 
                return View("Error");
            }
        }

        public ActionResult CursoEdit(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdCurso", id));
            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso infoCurso = new Curso();

            if (dtCurso.Rows.Count > 0) //lo encontro
            {
                infoCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                infoCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                infoCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                

                return View(infoCurso);
            }
            else
            {  //no lo encontro 
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult CursoEdit(int id, Curso datosCurso)
        {
            // update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", id));
            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datosCurso.IdEmpleado));
            

            BaseHelper.ejecutarConsulta("sp_Curso_Actualizar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Curso");
        }
    }
}
