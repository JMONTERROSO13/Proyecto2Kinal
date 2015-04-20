using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    
    public class CuentaAhorro
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 7)]
        public string nombreCuenta { get; set; }

        public int TipoID { get; set; }
        public Tipo Tipo { get; set; }

        public decimal saldo { get; set; }

        public virtual ICollection<AbonoAhorro> Abonos{ get; set; }
        public virtual ICollection<RetiroAhorro> Retiros{ get; set; }
         
        /* Enlace con persona / usuarios
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } 
        */
    }
}