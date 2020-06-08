using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nota2
{
    class Cliente
    {
        public string Id_cliente { get; set; }
        private string Rut_cliente;
        public string _Rut { get { return this.Rut_cliente; } set { this.Rut_cliente = value; } }
        private string Nombre_cliente { get; set; }
        public string _Nombre_cliente{ get { return this.Nombre_cliente; } set { this.Nombre_cliente = value; } }
        public string Apellido_cliente { get; set; }
        public string Fecha_nacimiento { get; set; }
        public string Sexo { get; set; }
        public string Estado_civil { get; set; }
    }
}
