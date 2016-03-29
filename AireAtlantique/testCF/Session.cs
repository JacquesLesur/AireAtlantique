using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Session
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        public List<Employe> listeEmploye { get; set; }

        [Required]
        public DateTime DateSession { get; set; }


    }
}

