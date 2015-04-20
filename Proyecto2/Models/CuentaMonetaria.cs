using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{

    public class CuentaMonetaria
    {
        public int Id { get; set; } 

        [StringLength(10, MinimumLength = 7)]
        public string nombreCuenta { get; set; }

        public int TipoID { get; set; }
        public Tipo Tipo { get; set; }

        public decimal saldo { get; set; }

        /* Enlace con persona / usuarios
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } 
        */
        public virtual ICollection<TarjetaCredito> TarjetasCreditos { get; set; }
        public virtual ICollection<TarjetaDebito> TarjetaDebito { get; set; }
        public virtual ICollection<Prestamo> Prestamos{ get; set; }
    }
}