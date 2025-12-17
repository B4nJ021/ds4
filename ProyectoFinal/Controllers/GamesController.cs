using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;


namespace ProyectoFinal.Controllers
{
    //[Authorize]
    public class GamesController : Controller
    {
        private GameDbContext db = new GameDbContext();
        private GameApiService apiService = new GameApiService();

        // GET: Games
        [AllowAnonymous]
        public async Task<ActionResult> Index(string searchTerm)
        {
            var games = await apiService.GetGamesAsync(searchTerm);
            ViewBag.SearchTerm = searchTerm;

            // Obtener favoritos del usuario actual
            int userId = (int)Session["UserId"];
            var favoriteGameIds = db.FavoriteGames
                .Where(f => f.UserId == userId)
                .Select(f => f.GameId)
                .ToList();

            ViewBag.FavoriteGameIds = favoriteGameIds;

            return View(games);
        }

        // GET: Games/MyFavorites
        [Authorize]
        public ActionResult MyFavorites()
        {
            int userId = int.Parse(User.Identity.Name);

            var favorites = db.FavoriteGames
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.DateAdded)
                .ToList();

            return View(favorites);
        }


        // POST: Games/AddToFavorites
        [HttpPost]
        public async Task<ActionResult> AddToFavorites(int gameId)
        {
            int userId = (int)Session["UserId"];

            // Verificar si ya está en favoritos
            var existing = db.FavoriteGames.FirstOrDefault(f => f.UserId == userId && f.GameId == gameId);
            if (existing != null)
            {
                return Json(new { success = false, message = "Este juego ya está en tus favoritos" });
            }

            // Obtener detalles del juego de la API
            var game = await apiService.GetGameByIdAsync(gameId);
            if (game == null)
            {
                return Json(new { success = false, message = "No se pudo obtener la información del juego" });
            }

            var favorite = new FavoriteGame
            {
                UserId = userId,
                GameId = gameId,
                GameName = game.Name,
                Company = game.GetPublisher(),
                ReleaseDate = DateTime.TryParse(game.Released, out DateTime date) ? (DateTime?)date : null,
                ImageUrl = game.BackgroundImage,
                Console = game.GetMainPlatform(),
                DateAdded = DateTime.Now
            };

            db.FavoriteGames.Add(favorite);
            db.SaveChanges();

            return Json(new { success = true, message = "Juego añadido a favoritos" });
        }

        // POST: Games/RemoveFromFavorites
        [HttpPost]
        public ActionResult RemoveFromFavorites(int favoriteGameId)
        {
            int userId = (int)Session["UserId"];
            var favorite = db.FavoriteGames.FirstOrDefault(f => f.FavoriteGameId == favoriteGameId && f.UserId == userId);

            if (favorite != null)
            {
                db.FavoriteGames.Remove(favorite);
                db.SaveChanges();
                return Json(new { success = true, message = "Juego eliminado de favoritos" });
            }

            return Json(new { success = false, message = "No se encontró el juego" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}