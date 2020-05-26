using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCLaboratorio.Models
{
    interface ICurso
    {
        List<Curso> obtenerCursos();
        Curso obtenerCurso(int IdCurso);
        void insertarCurso(Curso datosCurso);
        void eliminarCurso(int IdCurso);
        void actualizarCurso(Curso datosCurso);
    }
}