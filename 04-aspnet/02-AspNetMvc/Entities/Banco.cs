using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _02_AspNetMvc.Entities
{
    public class Banco
    {
        public Banco()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Display(Name = "Codigo de Banco")]
        public int BancoId { get; set; }

        [Required(ErrorMessage = "Nombre Banco obligatorio")]
        [Display(Name = "Nombre Banco")]
        [StringLength(50, ErrorMessage = "La {0}, Debe ser al Menos {2} y Màximo de {1} Caracteres", MinimumLength = 10)]
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
