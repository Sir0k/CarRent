namespace CarRent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarInRent")]
    public partial class CarInRent
    {
        [Key]
        public int ID_order { get; set; }

        public int ID_car { get; set; }

        public int ID_worker { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_rent_day { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_rent_day { get; set; }
    }
}
