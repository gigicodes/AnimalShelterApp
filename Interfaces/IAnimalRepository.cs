using AnimalShelterApp.Models;

namespace AnimalShelterApp.Interfaces
{
    public interface IAnimalRepository
    {
        List<Animal> GetAllAnimals();
        Animal? GetById(int id);
        void Add(Animal animal);
        void Update(Animal animal);
    }
}
