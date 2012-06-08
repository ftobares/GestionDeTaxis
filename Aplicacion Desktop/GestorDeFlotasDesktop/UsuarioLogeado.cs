using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    public class UsuarioLogeado
    {
        public static string usuarioID { get; set; }

        private static UsuarioLogeado instance;

        private UsuarioLogeado() { }

        public static UsuarioLogeado Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioLogeado();
                }
                return instance;
            }
        }
    }
}
