using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;



namespace MVCLaboratorio.Models
{
    public class RepositorioCurso : ICurso
    {

        public List<Curso> obtenerCursos()
        {
            //Implementacion de funcionalidad
            DataTable dtCurso;
            dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarTodo", CommandType.StoredProcedure);

            List<Curso> lstCurso = new List<Curso>();

            //convertir el DataTable a una lista de curso List<Curso>
            foreach (DataRow item in dtCurso.Rows)
            {
                Curso CursoAux = new Curso();
                CursoAux.IdCurso = Convert.ToInt32(item["IdCurso"].ToString());
                CursoAux.Descripcion = item["Descripcion"].ToString();
                CursoAux.IdEmpleado = Convert.ToInt32(item["IdEmpleado"].ToString());
                lstCurso.Add(CursoAux);
            }

            return (lstCurso);
        }

        public Curso obtenerCurso(int IdCurso)
        {
            DataTable dtCurso;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", IdCurso));
            dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);

            //Convertir dtCurso en objeto
            Curso datosCurso = new Curso();

            if (dtCurso.Rows.Count > 0)//si lo encuentra
            {
                datosCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                datosCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                datosCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());


                return datosCurso;
            }
            else //si no lo encuentra
            {
                return null;
            }
        }

        public void insertarCurso(Curso datosCurso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datosCurso.IdEmpleado));


            BaseHelper.ejecutarConsulta("sp_Curso_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarCurso(int IdCurso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", IdCurso));

            BaseHelper.ejecutarConsulta("sp_Curso_Eliminar", CommandType.StoredProcedure, parametros);

            
        }

        public void actualizarCurso(Curso datosCurso)
        {
            // update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", datosCurso.IdCurso));
            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datosCurso.IdEmpleado));


            BaseHelper.ejecutarConsulta("sp_Curso_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}