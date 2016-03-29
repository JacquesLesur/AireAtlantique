using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Employe
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

    }
}
