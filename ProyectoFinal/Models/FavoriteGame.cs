using ProyectoFinal.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class FavoriteGame
    {
        [Key]
        public int FavoriteGameId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GameId { get; set; }

        [StringLength(200)]
        public string GameName { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(100)]
        public string Console { get; set; }

        public DateTime DateAdded { get; set; }

        // Navegación
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}