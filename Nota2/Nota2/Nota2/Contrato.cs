using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nota2
{
    class Contrato
    {
        public string Nro_contrato { get; set; }

        private string Rut_contrato;
        public string _Rut_contrato { get { return this.Rut_contrato; } set { this.Rut_contrato = value; } }
        public string Plan_asociado { get; set; }
        public string Poliza{ get; set; }
        public string Fecha_inicio{ get; set; }
        public string Fecha_termino { get; set; }
        public string Declaracion_medica { get; set; }
        public string Prima_mensual { get; set; }
        public string Prima_anual { get; set; }
        public string Observacion { get; set; }
    }
}
