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
        public int IdEmpelado { get; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }

    public class Curso
    {
        public int IdCurso { get; }
        public string Descripcion { get; set; }
        public int IdEmpleado { get; }
    }

    public class Curso_Tema
    {
        public int IdCT { get; }
        public int IdCurso { get; }
        public int IdTema { get; }
    }

    public class Video
    {
        public int IdVideo { get; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }

    public class Curso_Tema_Video
    {
        public int IdCTV { get; }
        public int IdCT { get; }
        public int IdVideo { get; }
    }
}