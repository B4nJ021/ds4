using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class CalculoModel
    {
        public int Id { get; set; }
        public string Operacion { get; set; }
        public decimal Resultado { get; set; }
        public DateTime FechaHora { get; set; }
    }

}