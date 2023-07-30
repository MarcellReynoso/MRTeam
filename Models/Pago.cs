using System;
using System.ComponentModel.DataAnnotations;

namespace mrteam.Models
{
    public class Pago
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El campo monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo Forma de Pago es obligatorio.")]
        public required string FormaPago { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

      }
}
