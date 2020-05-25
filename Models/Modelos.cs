using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    public class Tema
    {
        public int IdTema { get; set; }
        public string Nombre { get; set; }
    }


    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }

    public class Curso
    {
        public int IdCurso { get; set; }
        public string Descripcion { get; set; }
        public int IdEmpleado { get; set; }
    }

    public class Curso_Tema
    {
        public int IdCT { get; set; }
        public int IdCurso { get; set; }
        public int IdTema { get; set; }
    }

    public class Video
    {
        public int IdVideo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }

    public class Curso_Tema_Video
    {
        public int IdCTV { get; set; }
        public int IdCT { get; set; }
        public int IdVideo { get; set; }
    }
}