namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vertebre")]
    public partial class Vertebre
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string genre { get; set; }

        [Required]
        [StringLength(128)]
        public string espece { get; set; }

        public bool ovipare { get; set; }

        public bool vivipare { get; set; }

        public bool ovovivipare { get; set; }

        public bool? aDesMembres { get; set; }

        public int? nbPenis { get; set; }

        public bool? peutVoler { get; set; }

        public int? nombreDeDoigts { get; set; }

        public bool? aDesPoils { get; set; }

        public bool? aDesDents { get; set; }

        [StringLength(50)]
        public string typeMarche { get; set; }

        [Required]
        [StringLength(50)]
        public string typeVertebre { get; set; }
    }
}
