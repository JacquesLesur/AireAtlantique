using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    class Employe
    {
        [Key]
        public int IDEmploye { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        public int numeroTelephone { get; set; }

        [Required]
        public DateTime dateNaissance { get; set; }


        public virtual Metier Metier { get; set; }

        public virtual ICollection<Session> listeSession { get; set; }
    }
}
