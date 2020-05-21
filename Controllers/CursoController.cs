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
                CursoAux.Descripcion = item["Descripcion"].ToString();
                lstCurso.Add(CursoAux);
            }

            return View(lstCurso);
        }

    }

}
