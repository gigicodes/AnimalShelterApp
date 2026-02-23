namespace AnimalShelterApp.Models
{
    public class Rabbit : Animal
    {
        public override string AnimalType => "Rabbit";
        public string Breed { get; set; } = string.Empty;
    }
}
