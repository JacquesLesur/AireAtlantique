using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Formation
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string Nom { get; set; }


        [Required]
        [StringLength(500)]
        public List<Employe> employe { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public int Validité { get; set; }

    }
}

