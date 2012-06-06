using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Funcionalidades
    {
        public int iId_Funcionalidad;
        public String sNombre;
        public string sDescripcion;

        public Funcionalidades(int _iId_Funcionalidad, String _sNombre, string _sDescripcion)
        {
            iId_Funcionalidad = _iId_Funcionalidad;
            sNombre = _sNombre;
            sDescripcion = _sDescripcion;
        }
    }
}
