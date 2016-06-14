using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    class Session
    {
        [Key]
        public int IDSession { get; set; }


        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        
        public int NombreMaxEmploye { get; set; }

        public virtual ICollection<Employe> listeEmploye { get; set; }

        [Required]
        public DateTime DateSession { get; set; }

        [Required]
        public virtual Formation Formation { get; set; }


    }
}

