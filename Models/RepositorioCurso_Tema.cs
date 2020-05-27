using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Models
{
    public class RepositorioCurso_Tema : ICurso_Tema
    {

        public List<Curso_Tema> obtenerCurso_Temas()
        {
            DataTable dtCurso_Tema;
            dtCurso_Tema = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_CONSULTARTODO", CommandType.StoredProcedure);

            List<Curso_Tema> lstCurso_Tema = new List<Curso_Tema>();

            //convertir el DataTable a una lista de videos List<Video>
            foreach (DataRow item in dtCurso_Tema.Rows)
            {
                Curso_Tema Curso_TemaAux = new Curso_Tema();
                Curso_TemaAux.IdCT = Convert.ToInt32(item["IdCT"].ToString());
                Curso_TemaAux.IdCurso = Convert.ToInt32(item["IdCurso"].ToString());
                Curso_TemaAux.IdTema = Convert.ToInt32(item["IdTema"].ToString());
                lstCurso_Tema.Add(Curso_TemaAux);
            }

            return (lstCurso_Tema);
        }

        public Curso_Tema obtenerCurso_Tema(int IdCT)
        {
            //Datos del video para el usuario antes de borrarlo
            DataTable dtCurso_Tema;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", IdCT));
            dtCurso_Tema = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_CONSULTARXID", CommandType.StoredProcedure, parametros);

            //Convertir dtCurso en objeto
            Curso_Tema datosCurso_Tema = new Curso_Tema();

            if (dtCurso_Tema.Rows.Count > 0)//si lo encuentra
            {
                datosCurso_Tema.IdCT = int.Parse(dtCurso_Tema.Rows[0]["IdCT"].ToString());
                datosCurso_Tema.IdCurso = int.Parse(dtCurso_Tema.Rows[0]["IdCurso"].ToString());
                datosCurso_Tema.IdTema = int.Parse(dtCurso_Tema.Rows[0]["IdTema"].ToString());


                return datosCurso_Tema;
            }
            else //si no lo encuentra
            {
                return null;
            }
        }

        public void insertarCurso_Tema(Curso_Tema datosCurso_Tema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));

            BaseHelper.ejecutarSentencia("SP_CURSO_TEMA_INSERT", CommandType.StoredProcedure, parametros);

           
        }

        public void eliminarCurso_Tema(int IdCT)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", IdCT));

            BaseHelper.ejecutarSentencia("SP_CURSO_TEMA_ELIMINAR", CommandType.StoredProcedure, parametros);

        }

        public void actualizarCurso_Tema(Curso_Tema datosCurso_Tema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", datosCurso_Tema.IdCT));
            parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));


            BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_ACTUALIZAR", CommandType.StoredProcedure, parametros);
        }
    }
}