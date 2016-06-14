using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    class Formation
    {
        [Key]
        public int IDFormation { get; set; }


        [Required]
        [StringLength(50)]
        public string Nom { get; set; }


        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public int Validité { get; set; }

        [Required]
        public Boolean Obligatoire { get; set; }

        public virtual ICollection<Metier> listMetier { get; set; }
    }
}

