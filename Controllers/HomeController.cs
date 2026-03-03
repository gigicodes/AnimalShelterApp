using System.Diagnostics;
using AnimalShelterApp.Models;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterApp.Services;

namespace AnimalShelterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnimalService _animalService;

        public HomeController(ILogger<HomeController> logger, AnimalService animalService)
        {
            _logger = logger;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            var animals = _animalService.GetAllAnimals()
                                        .Where(a => !a.IsAdopted)
                                        .ToList();

            var random = new Random();
            var animalOfTheDay = animals.Count > 0
                ? animals[random.Next(animals.Count)]
                : null;

            return View(animalOfTheDay);
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
