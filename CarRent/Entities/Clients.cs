namespace CarRent.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        [Key]
        public int ID_client { get; set; }

        [Required]
        [StringLength(15)]
        public string surname { get; set; }

        [Required]
        [StringLength(15)]
        public string name { get; set; }

        [Required]
        [StringLength(15)]
        public string patronymic { get; set; }

        public int passport_data { get; set; }

        [Required]
        [StringLength(10)]
        public string city { get; set; }

        [Required]
        [StringLength(100)]
        public string adress { get; set; }

        [Required]
        [StringLength(10)]
        public string phone_number { get; set; }
    }
}
