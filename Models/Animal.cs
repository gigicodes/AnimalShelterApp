namespace AnimalShelterApp.Models
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsAdopted { get; set; } = false;
        public abstract string AnimalType { get; }
    }
}