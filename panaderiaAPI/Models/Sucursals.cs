namespace panaderiaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sucursals
    {
        [Key]
        public int SucursalID { get; set; }

        public int AdminID { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        public byte[] Imagen { get; set; }

        public virtual Admins Admins { get; set; }
    }
}
