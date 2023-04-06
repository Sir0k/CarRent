namespace CarRent.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roles
    {
        [Key]
        public int ID_roles { get; set; }

        [Required]
        [StringLength(10)]
        public string role { get; set; }

        [Required]
        [StringLength(10)]
        public string salary { get; set; }
    }
}
