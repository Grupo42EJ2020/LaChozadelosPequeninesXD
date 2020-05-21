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
    public class RepositorioTema : ITema
    {
        public List<Tema> obtenerTemas()
        {
            DataTable dtTema;
            dtTema = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarTodo", CommandType.StoredProcedure);

            List<Tema> lstTema = new List<Tema>();

            //convertir el DataTable a una lista de videos List<Video>
            foreach (DataRow item in dtTema.Rows)
            {
                Tema TemaAux = new Tema();
                TemaAux.IdTema = int.Parse(item["IdTema"].ToString());
                TemaAux.Nombre = item["Nombre"].ToString();

                lstTema.Add(TemaAux);
            }

            return lstTema;
        }

        Tema ITema.obtenerTema(int IdTema)
        {
            throw new NotImplementedException();
        }

        void ITema.insertarTema(Tema datosTema)
        {
            throw new NotImplementedException();
        }

        void ITema.eliminarTema(int IdTema)
        {
            throw new NotImplementedException();
        }

        void ITema.actualizarTema(Tema datosTema)
        {
            throw new NotImplementedException();
        }
    }
}