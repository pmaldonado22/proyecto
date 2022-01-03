using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panaderiaUWP.Modelos
{
    class Pastels
    {
        public int PastelID { get; set; }

        public int AdminID { get; set; }

        public string NombrePastel { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public byte[] Imagen { get; set; }
    }
}
