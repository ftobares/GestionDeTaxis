using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class RolPantalla
    {
        public string sRolID;
        public string sPantallaId;
        public char cAcceso;

        public RolPantalla(string _sRolID, string _sPantallaId, char _cAcceso)
        {
            sRolID = _sRolID;
            sPantallaId = _sPantallaId;
            cAcceso = _cAcceso;
        }
    }
}
