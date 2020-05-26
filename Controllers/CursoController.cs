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
        
        // GET: /Curso/

        RepositorioCurso repoCurso = new  RepositorioCurso(); 

        public ActionResult Index()
        {
            return View();
        }

        //Muestra todo lo que hay en la base de datos
        public ActionResult Curso()
        {
            return View(repoCurso.obtenerCursos());
        }

        //Busca el registro a eliminar
        public ActionResult CursoDelete(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }
        
        //Elimina el registro
        [HttpPost]
        public ActionResult CursoDelete(int id, FormCollection datos)
        {
            repoCurso.eliminarCurso(id);
            return RedirectToAction("Curso");
        }

        //Busca el registro seleccionado
        public ActionResult CursoDetails(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }


        //Busca el registro a editar
        public ActionResult CursoEdit(int id)
        {
            return View(repoCurso.obtenerCurso(id));
            }
        
        //Edita el registro
        [HttpPost]
        public ActionResult CursoEdit(int id, Curso datosCurso)
        {
            datosCurso.IdCurso = id;
            repoCurso.actualizarCurso(datosCurso);
            
            return RedirectToAction("Curso");
        }


       
        // En el insert, el IdCurso es autoincrementable y IdEstudiante debe elegirse en base a los 
        //id que existen en la tabla Estudiante
        public ActionResult CursoCreate()
        {
            return View();
        }
         
        //Inserta un registro
        [HttpPost]
        public ActionResult CursoCreate(Curso datosCurso)
        {

            repoCurso.insertarCurso(datosCurso);
                
           

            return RedirectToAction("Curso");
        }
    }

}

