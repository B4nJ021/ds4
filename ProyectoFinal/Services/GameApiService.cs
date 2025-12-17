using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoFinal.Services
{
    public class GameApiService
    {
        private readonly string _apiBaseUrl = "https://www.cheapshark.com/api/1.0";

        public async Task<List<GameDto>> GetGamesAsync(string searchTerm = "")
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Si no hay búsqueda, obtener deals populares
                    string url = string.IsNullOrEmpty(searchTerm)
                        ? $"{_apiBaseUrl}/deals?pageSize=20&sortBy=Metacritic"
                        : $"{_apiBaseUrl}/games?title={searchTerm}&limit=20";

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(searchTerm))
                    {
                        var deals = JsonConvert.DeserializeObject<List<CheapSharkDeal>>(json);
                        return deals.Select(d => new GameDto
                        {
                            Id = int.Parse(d.GameID ?? "0"),
                            Name = d.Title,
                            Released = "N/A",
                            BackgroundImage = d.Thumb,
                            Platforms = new List<PlatformInfo>
                            {
                                new PlatformInfo { Platform = new Platform { Name = "PC" } }
                            },
                            Publishers = new List<Publisher>
                            {
                                new Publisher { Name = d.StoreID == "1" ? "Steam" : "Varios" }
                            },
                            Price = decimal.Parse(d.SalePrice ?? "0"),
                            NormalPrice = decimal.Parse(d.NormalPrice ?? "0")
                        }).ToList();
                    }
                    else
                    {
                        var games = JsonConvert.DeserializeObject<List<CheapSharkGame>>(json);
                        return games.Select(g => new GameDto
                        {
                            Id = int.Parse(g.GameID ?? "0"),
                            Name = g.External,
                            Released = "N/A",
                            BackgroundImage = g.Thumb,
                            Platforms = new List<PlatformInfo>
                            {
                                new PlatformInfo { Platform = new Platform { Name = "PC" } }
                            },
                            Publishers = new List<Publisher>
                            {
                                new Publisher { Name = "Varios" }
                            },
                            Price = decimal.Parse(g.Cheapest ?? "0")
                        }).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return new List<GameDto>();
                }
            }
        }

        public async Task<GameDto> GetGameByIdAsync(int gameId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string url = $"{_apiBaseUrl}/games?id={gameId}";

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var gameData = JsonConvert.DeserializeObject<CheapSharkGameDetail>(json);

                    if (gameData?.Info != null)
                    {
                        return new GameDto
                        {
                            Id = gameId,
                            Name = gameData.Info.Title,
                            Released = "N/A",
                            BackgroundImage = gameData.Info.Thumb,
                            Platforms = new List<PlatformInfo>
                            {
                                new PlatformInfo { Platform = new Platform { Name = "PC" } }
                            },
                            Publishers = new List<Publisher>
                            {
                                new Publisher { Name = gameData.Info.Publisher ?? "Desconocido" }
                            }
                        };
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }
    }

    // DTOs para CheapShark
    public class CheapSharkDeal
    {
        [JsonProperty("gameID")]
        public string GameID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("salePrice")]
        public string SalePrice { get; set; }

        [JsonProperty("normalPrice")]
        public string NormalPrice { get; set; }

        [JsonProperty("storeID")]
        public string StoreID { get; set; }
    }

    public class CheapSharkGame
    {
        [JsonProperty("gameID")]
        public string GameID { get; set; }

        [JsonProperty("external")]
        public string External { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("cheapest")]
        public string Cheapest { get; set; }
    }

    public class CheapSharkGameDetail
    {
        [JsonProperty("info")]
        public GameInfo Info { get; set; }
    }

    public class GameInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }
    }

    // DTOs compartidos
    public class GameApiResponse
    {
        [JsonProperty("results")]
        public List<GameDto> Results { get; set; }
    }

    public class GameDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImage { get; set; }

        [JsonProperty("platforms")]
        public List<PlatformInfo> Platforms { get; set; }

        [JsonProperty("publishers")]
        public List<Publisher> Publishers { get; set; }

        public decimal Price { get; set; }
        public decimal NormalPrice { get; set; }

        public string GetMainPlatform()
        {
            return Platforms != null && Platforms.Count > 0
                ? Platforms[0].Platform.Name
                : "PC";
        }

        public string GetPublisher()
        {
            return Publishers != null && Publishers.Count > 0
                ? Publishers[0].Name
                : "Desconocido";
        }
    }

    public class PlatformInfo
    {
        [JsonProperty("platform")]
        public Platform Platform { get; set; }
    }

    public class Platform
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Publisher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}