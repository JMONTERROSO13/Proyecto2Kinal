﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class CargoCredito
    {
        public int Id { get; set; }

        public int CuentaMonetariaId { get; set; }
        public virtual CuentaMonetaria CuentaMonetaria { get; set; }

        [StringLength(10, MinimumLength = 4)]
        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

    }
}