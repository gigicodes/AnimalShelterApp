using AnimalShelterApp.Models;
using AnimalShelterApp.Interfaces;

namespace AnimalShelterApp.Services
{
    public class AnimalService : IAdoptable, ITrainable
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }
        public List<Animal> GetAllAnimals()
        {
            return _repository.GetAllAnimals();
        }
        public Animal? GetAnimal(int id)
        {
            return _repository.GetById(id);
        }
        public void AddAnimal(Animal animal)
        {
            _repository.Add(animal);
        }
        public void Adopt(int animalId)
        {
            var animal = _repository.GetById(animalId);
            if (animal != null)
            {
                animal.IsAdopted = true;
                _repository.Update(animal);
            }
        }
        public string Train(int animalId)
        {
            var animal = _repository.GetById(animalId);
            if (animal == null)

                return "Animal not found.";
            return animal switch
            {
                Dog dog => $"{dog.Name} the {dog.Breed} has been trained to sit and stay.",
                Cat cat => $"{cat.Name} the cat has been trained to use the litter box.",
                _ => $"{animal.Name} has completed training."
            };
        }
    }
}
