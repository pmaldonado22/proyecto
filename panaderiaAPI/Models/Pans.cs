namespace panaderiaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pans
    {
        [Key]
        public int PanID { get; set; }

        public int AdminID { get; set; }

        [Required]
        public string NombrePan { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public byte[] Imagen { get; set; }

        public virtual Admins Admins { get; set; }
    }
}
