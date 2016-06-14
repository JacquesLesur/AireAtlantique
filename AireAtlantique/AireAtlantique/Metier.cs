using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    class Metier
    {
        [Key]
        public int IDMetier { get; set; }


        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        public virtual ICollection<Employe> listeEmploye { get; set; }

        public virtual ICollection<Formation> listFormation { get; set; }
    }
}
