using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Pantalla
    {
        public string sPantallaID;
        public string sDescripcion;

        public Pantalla(string _sPantallaID, string _sDescripcion)
        {
            sPantallaID = _sPantallaID;
            sDescripcion = _sDescripcion;
        }
    }
}
