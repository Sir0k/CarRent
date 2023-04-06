namespace CarRent.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AvailableCars
    {
        [Key]
        public int ID_car { get; set; }

        [Required]
        [StringLength(15)]
        public string brand { get; set; }

        [Required]
        [StringLength(15)]
        public string model { get; set; }

        [Required]
        [StringLength(15)]
        public string engine { get; set; }

        [Required]
        [StringLength(15)]
        public string body { get; set; }

        [Required]
        [StringLength(15)]
        public string color { get; set; }

        public int price_for_day { get; set; }

        public bool availability { get; set; }

        public Byte[] ImageData { get; set; }
    }
}
