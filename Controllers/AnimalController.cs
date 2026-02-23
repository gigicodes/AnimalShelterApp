using Microsoft.AspNetCore.Mvc;
using AnimalShelterApp.Services;
using AnimalShelterApp.Models;

namespace AnimalShelterApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalService _animalService;
        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }
        public IActionResult Index()
        {
            var animals = _animalService.GetAllAnimals();
            return View(animals);
        }
        public IActionResult Details(int id)
        {
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
                return NotFound();
            return View(animal);
        }
        [HttpPost]
        public IActionResult Adopt(int id)
        {
            _animalService.Adopt(id);
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public IActionResult Train(int id)
        {
            var result = _animalService.Train(id);
            TempData["TrainingResult"] = result;
            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string name, int age, string type, string? breed, bool? isIndoor)
        {
            Animal Animal = type.ToLower() switch
            {
                "dog" => new Dog { Name = name, Age = age, Breed = breed ?? "Unknown", IsAdopted = false },
                "cat" => new Cat { Name = name, Age = age, IsIndoor = isIndoor ?? true, IsAdopted = false },
                _ => throw new ArgumentException("Invalid animal type")
            };
            _animalService.AddAnimal(Animal);
            return RedirectToAction("Index");
        }

    }
}
