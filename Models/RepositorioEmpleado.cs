using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using MVCLaboratorio.Utilerias;
using System.Data.SqlClient;

namespace MVCLaboratorio.Models
{
    public class RepositorioEmpleado
    {
        public List<Empleado> obtenerEmpleado()
        {
            DataTable dtEmpleado;
            dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> lstEmpleado = new List<Empleado>();

            foreach (DataRow item in dtEmpleado.Rows)
            {
                Empleado EmpleadoAux = new Empleado();
                EmpleadoAux.IdEmpleado = Convert.ToInt32(item["IdEmpleado"].ToString()); //int.Parse(item["IdEmpleado"].ToString());
                EmpleadoAux.Nombre = item["Nombre"].ToString();
                EmpleadoAux.Direccion = item["Direccion"].ToString();

                lstEmpleado.Add(EmpleadoAux);
            }
            return lstEmpleado;
        }

        public Empleado obtenerEmpleado(int IdEmpleado)
        {
            //obtener datos del empleado
            DataTable dtEmpleado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("IdEmpleado", IdEmpleado));

            dtEmpleado = BaseHelper.ejecutarConsulta("spEmpleadoConsultarPorID", CommandType.StoredProcedure, parametros);
            //Convertir el dtEmpleado a un objeto Empleado
            Empleado datosEmpleado = new Empleado();
            if (dtEmpleado.Rows.Count > 0)
            {
                datosEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                datosEmpleado.Nombre = dtEmpleado.Rows[0]["Nombre"].ToString();
                datosEmpleado.Direccion = dtEmpleado.Rows[0]["Direccion"].ToString();
                return datosEmpleado;
            }
            else
            {
                return null;
            }
        }

        public void insertarEmpleado(Empleado datosEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));
            BaseHelper.ejecutarSentencia("spEmpleadoInsertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarEmpleado(int IdEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", IdEmpleado));

            BaseHelper.ejecutarSentencia("spEmpleadoEliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarEmpleado(Empleado datosEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", datosEmpleado.IdEmpleado));
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));

            BaseHelper.ejecutarConsulta("spEmpleadoActualizar", CommandType.StoredProcedure, parametros);
        }
    }
}