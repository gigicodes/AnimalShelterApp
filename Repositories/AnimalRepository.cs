using AnimalShelterApp.Models;
using AnimalShelterApp.Interfaces;

namespace AnimalShelterApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private static List<Animal> _animals = new List<Animal>
        {
            new Dog { Id = 1, Name = "Buddy", Age = 3, Breed = "Golden Retriever", IsAdopted = false },
            new Cat { Id = 2, Name = "Whiskers", Age = 2, IsIndoor = true, IsAdopted = false },
            new Dog { Id = 3, Name = "Max", Age = 5, Breed = "Labrador", IsAdopted = false },
            new Cat { Id = 4, Name = "Luna", Age = 1, IsIndoor = false, IsAdopted = false }
        };

        public List<Animal> GetAllAnimals()
        {
            return _animals;
        }
        public Animal? GetById(int id)
        {
            return _animals.FirstOrDefault(a => a.Id == id);
        }
        public void Add(Animal animal)
        {
            animal.Id = _animals.Max(a => a.Id) + 1; // Simple ID generation
            _animals.Add(animal);
        }
        public void Update(Animal animal)
        {
            var existingAnimal = GetById(animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Age = animal.Age;
                existingAnimal.IsAdopted = animal.IsAdopted;
                if (existingAnimal is Dog existingDog && animal is Dog updatedDog)
                {
                    existingDog.Breed = updatedDog.Breed;
                }
                else if (existingAnimal is Cat existingCat && animal is Cat updatedCat)
                {
                    existingCat.IsIndoor = updatedCat.IsIndoor;
                }
            }
        }
    }
}
