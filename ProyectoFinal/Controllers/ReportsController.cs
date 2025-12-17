using ProyectoFinal.Data;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Reports/Sales
        public ActionResult Sales(int? gameId, DateTime? startDate, DateTime? endDate)
        {
            var query = db.GameSales.AsQueryable();

            if (gameId.HasValue)
            {
                query = query.Where(s => s.GameId == gameId.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(s => s.SaleDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(s => s.SaleDate <= endDate.Value);
            }

            var sales = query.OrderByDescending(s => s.SaleDate).ToList();

            // Calcular totales
            ViewBag.TotalCopiesSold = sales.Sum(s => s.CopiesSold);
            ViewBag.TotalRevenue = sales.Sum(s => s.Revenue);
            ViewBag.GameCount = sales.Select(s => s.GameId).Distinct().Count();

            // Lista de juegos para el filtro
            var games = db.FavoriteGames
                .Select(f => new { f.GameId, f.GameName })
                .Distinct()
                .ToList();
            ViewBag.Games = new SelectList(games, "GameId", "GameName");

            return View(sales);
        }

        // GET: Reports/GameDetails
        public ActionResult GameDetails(int gameId)
        {
            var sales = db.GameSales
                .Where(s => s.GameId == gameId)
                .OrderByDescending(s => s.SaleDate)
                .ToList();

            if (!sales.Any())
            {
                ViewBag.Message = "No hay datos de ventas para este juego";
                return View(new List<GameSales>());
            }

            ViewBag.GameName = sales.First().GameName;
            ViewBag.TotalCopies = sales.Sum(s => s.CopiesSold);
            ViewBag.TotalRevenue = sales.Sum(s => s.Revenue);
            ViewBag.AveragePrice = sales.Any() ? sales.Sum(s => s.Revenue) / sales.Sum(s => s.CopiesSold) : 0;

            // Datos para gráfico (ventas por mes)
            var monthlySales = sales
                .GroupBy(s => new { s.SaleDate.Year, s.SaleDate.Month })
                .Select(g => new
                {
                    Month = $"{g.Key.Month}/{g.Key.Year}",
                    Copies = g.Sum(s => s.CopiesSold),
                    Revenue = g.Sum(s => s.Revenue)
                })
                .OrderBy(x => x.Month)
                .ToList();

            ViewBag.MonthlyData = monthlySales;

            return View(sales);
        }

        // GET: Reports/TopGames
        public ActionResult TopGames(int top = 10)
        {
            var topGames = db.GameSales
                .GroupBy(s => new { s.GameId, s.GameName })
                .Select(g => new TopGameViewModel
                {
                    GameId = g.Key.GameId,
                    GameName = g.Key.GameName,
                    TotalCopiesSold = g.Sum(s => s.CopiesSold),
                    TotalRevenue = g.Sum(s => s.Revenue)
                })
                .OrderByDescending(g => g.TotalRevenue)
                .Take(top)
                .ToList();

            ViewBag.TopCount = top;
            return View(topGames);
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

    // ViewModel para el reporte de top juegos
    public class TopGameViewModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int TotalCopiesSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}