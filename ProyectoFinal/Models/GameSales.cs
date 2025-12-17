using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class GameSales
    {
        [Key]
        public int SalesId { get; set; }

        [Required]
        public int GameId { get; set; }

        [StringLength(200)]
        public string GameName { get; set; }

        [Required]
        public int CopiesSold { get; set; }

        [Required]
        public decimal Revenue { get; set; }

        [StringLength(100)]
        public string Console { get; set; }

        public DateTime SaleDate { get; set; }
    }
}