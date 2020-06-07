using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nota2
{
    class User
    {
        public string Id { get; set; }
        private string Rut;
        public string _Rut{ get { return this.Rut; } set{this.Rut = value; } }
        private string Usuario { get; set; }
        public string _Usuario { get { return this.Usuario; } set { this.Usuario = value; } }
        public string Contraseña { get; set; }
        public string Foto { get; set; }
    }
}
