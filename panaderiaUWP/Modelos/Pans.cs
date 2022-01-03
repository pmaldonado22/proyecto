using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panaderiaUWP.Modelos
{
    class Pans
    {
        public int PanID { get; set; }

        public int AdminID { get; set; }

        public string NombrePan { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public byte[] Imagen { get; set; }

    }
}
