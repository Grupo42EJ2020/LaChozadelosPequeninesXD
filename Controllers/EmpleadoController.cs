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
            dtEmpleado = BaseHelper.ejecutarConsulta("sp_Video_ConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> lstEmpleado = new List<Empleado>();

            foreach (DataRow item in dtEmpleado.Rows)
            {
                Empleado EmpleadoAux = new Empleado();
                EmpleadoAux.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                EmpleadoAux.Nombre = item["Nombre"].ToString();
                EmpleadoAux.Direccion = item["Direccion"].ToString();

                lstEmpleado.Add(EmpleadoAux);
            }
            return View(lstEmpleado);
        }
        //Metodo para borrar videos
        public ActionResult EmpleadoDelete(int id) 
        {
            //obtener datos del empleado
            DataTable dtEmpleado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", id));

            dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);
            //Convertir el dtEmpleado a un objeto Empleado
            Empleado datosEmpleado = new Empleado();
            if (dtEmpleado.Rows.Count > 0)
            {
                datosEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                datosEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                datosEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();
                return View(datosEmpleado);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult EmpleadoDelete(int id, FormCollection datos)
        {
            //REalizar delete del registro
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", id));

            BaseHelper.ejecutarSentencia("spEmpleadoEliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Empleado");
        }
        public ActionResult EmpleadoDetails(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", id));
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado infoEmpleado = new Empleado();
            if (dtEmpleado.Rows.Count > 0)
            {
                infoEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                infoEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                infoEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();
                return View(infoEmpleado);
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult EmpleadoEdit(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", id));
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado infoEmpleado = new Empleado();
            if (dtEmpleado.Rows.Count > 0)
            {
                infoEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                infoEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                infoEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();
                return View(infoEmpleado);
            }
            else
            {
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
        }
    }
}
