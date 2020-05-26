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
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Video()
        {
            DataTable dtVideos;
            dtVideos = BaseHelper.ejecutarConsulta("sp_Video_ConsultarTodo", CommandType.StoredProcedure);

            List<Video> lstVideos = new List<Video>();

            //convertir el DataTable a una lista de videos List<Video>
            foreach (DataRow item in dtVideos.Rows)
            {
                Video videoAux = new Video();
                videoAux.IdVideo = int.Parse(item["IdVideo"].ToString());
                videoAux.Nombre = item["Nombre"].ToString();
                videoAux.Url = item["Url"].ToString();
                videoAux.FechaPublicacion = DateTime.Parse(item["FechaPublicacion"].ToString());

                lstVideos.Add(videoAux);
            }

            return View(lstVideos);
        }
    

        public ActionResult VideoDelete(int id)
        {
            DataTable dtVideo;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", id));

            dtVideo = BaseHelper.ejecutarConsulta("sp_Video_ConsultarPorID", CommandType.StoredProcedure, parametros);

            //convertir el dtVideo a un objeto Video
            Video datosVideo = new Video();

            if (dtVideo.Rows.Count > 0) //si lo encontro
            {
                datosVideo.IdVideo = int.Parse(dtVideo.Rows[0]["IdVideo"].ToString());
                datosVideo.Nombre = dtVideo.Rows[0]["Nombre"].ToString();
                datosVideo.Url = dtVideo.Rows[0]["Url"].ToString();
                datosVideo.FechaPublicacion = DateTime.Parse(dtVideo.Rows[0]["FechaPublicacion"].ToString());

                return View(datosVideo);
            }
            else
            { //no lo encontro 
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult VideoDelete(int id, FormCollection datos)
        {
            //realizar el delete del registro
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", id));

            BaseHelper.ejecutarSentencia("sp_Video_Eliminar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Video");
        }

        public ActionResult VideoDetails(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdVideo",id ));
            DataTable dtVideo = BaseHelper.ejecutarConsulta("sp_Video_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Video infoVideo = new Video();

            if (dtVideo.Rows.Count > 0) //lo encontro
            {
                infoVideo.IdVideo = int.Parse(dtVideo.Rows[0]["IdVideo"].ToString());
                infoVideo.Nombre = dtVideo.Rows[0]["Nombre"].ToString();
                infoVideo.Url = dtVideo.Rows[0]["Url"].ToString();
                infoVideo.FechaPublicacion = DateTime.Parse(dtVideo.Rows[0]["FechaPublicacion"].ToString());

                return View(infoVideo);
            }
            else {  //no lo encontro 
                return View("Error");    
            }
        }
    

        public ActionResult VideoEdit(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@IdVideo",id ));
            DataTable dtVideo = BaseHelper.ejecutarConsulta("sp_Video_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Video infoVideo = new Video();

            if (dtVideo.Rows.Count > 0) //lo encontro
            {
                infoVideo.IdVideo = int.Parse(dtVideo.Rows[0]["IdVideo"].ToString());
                infoVideo.Nombre = dtVideo.Rows[0]["Nombre"].ToString();
                infoVideo.Url = dtVideo.Rows[0]["Url"].ToString();
                infoVideo.FechaPublicacion = DateTime.Parse(dtVideo.Rows[0]["FechaPublicacion"].ToString());

                return View(infoVideo);
            }
            else {  //no lo encontro 
                return View("Error");    
            }
        }
    }
}
