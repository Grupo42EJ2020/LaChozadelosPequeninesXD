using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCLaboratorio.Models
{
    interface ITema
    {
        List<Tema> obtenerTemas();
        Tema obtenerTema(int IdTema);
        void insertarTema(Tema datosTema);
        void eliminarTema(int IdTema);
        void actualizarTema(Tema datosTema);
    }
}
