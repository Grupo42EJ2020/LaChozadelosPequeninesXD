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
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Empleado()
        {

            DataTable dtEmpleado;
            dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> lstEmpleado = new List<Empleado>();

            foreach (DataRow item in dtEmpleado.Rows)
            {
                Empleado EmpleadoAux = new Empleado();
                EmpleadoAux.IdEmpleado = Convert.ToInt32(item["IdEmpleado"].ToString());
                EmpleadoAux.Nombre = item["Nombre"].ToString();
                EmpleadoAux.Direccion = item["Direccion"].ToString();
                lstEmpleado.Add(EmpleadoAux);
            }
            return View(lstEmpleado);
        }
       /*
        //Metodo para Borrar Empleado
        public ActionResult EmpleadoDelete(int id)
        {
            //obtener los datos del Empleado para mostrarlo al usuario antes de borrarlo
            DataTable dtEmpleado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));

            dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);

            //convertir el dtEmpleado a un objeto Empleado
            Empleado datosEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0) //si lo encontro
            {
                datosEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                datosEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                datosEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();

                return View(datosEmpleado);
            }
            else
            { //no lo encontro 
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EmpleadoDelete(int id, FormCollection datos)
        {
            //realizar el delete del registro
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));

            BaseHelper.ejecutarSentencia("spEmpleadoEliminar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Empleado");
        }
        public ActionResult EmpleadoDetails(int id)
        {
            //obtener la info del Empleado
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdEmpleado", id));
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);

            Video infoEmpleado = new Video();

            if (dtEmpleado.Rows.Count > 0) //lo encontro
            {
                infoEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                infoEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                infoEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();


                return View(infoEmpleado);
            }
            else
            {  //no lo encontro 
                return View("Error");
            }
        }

        public ActionResult EmpleadoEdit(int id)
        {
            //obtener la info del video
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdEmpleado", id));
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);

            Video infoEmpleado = new Video();

            if (dtEmpleado.Rows.Count > 0) //lo encontro
            {
                infoEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                infoEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                infoEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();


                return View(infoEmpleado);
            }
            else
            {  //no lo encontro 
                return View("Error");
            }
        }
        public ActionResult EmpleadoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadoCreate(string Nombre, string Direccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", Nombre));
            parametros.Add(new SqlParameter("@Direccion", Direccion));
            BaseHelper.ejecutarSentencia("spEmpleadoInsertar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Empleado");
        } */

    }
}
