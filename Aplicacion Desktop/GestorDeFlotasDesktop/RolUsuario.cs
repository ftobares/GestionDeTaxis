using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class RolUsuario
    {
        public string sUsuarioID;
        public string sRolID;

        public RolUsuario(string _sUsuarioID, string _sRolID)
        {
            sUsuarioID = _sUsuarioID;
            sRolID = _sRolID;
        }
    }
}
