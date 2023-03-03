namespace CarRent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Workers
    {
        [Key]
        public int ID_worker { get; set; }

        [Required]
        [StringLength(15)]
        public string name { get; set; }

        [Required]
        [StringLength(15)]
        public string surname { get; set; }

        [Required]
        [StringLength(15)]
        public string patronymic { get; set; }

        [Required]
        [StringLength(15)]
        public string role { get; set; }

        [Required]
        [StringLength(10)]
        public string phone { get; set; }

        [Required]
        [StringLength(15)]
        public string login { get; set; }

        [Required]
        [StringLength(15)]
        public string password { get; set; }
    }
}
