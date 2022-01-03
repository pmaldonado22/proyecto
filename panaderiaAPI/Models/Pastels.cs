namespace panaderiaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pastels
    {
        [Key]
        public int PastelID { get; set; }

        public int AdminID { get; set; }

        [Required]
        public string NombrePastel { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public byte[] Imagen { get; set; }

        public virtual Admins Admins { get; set; }
    }
}
