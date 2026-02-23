namespace AnimalShelterApp.Models
{
    public class Dog : Animal
    {
        public string Breed { get; set; } = string.Empty;
        public override string AnimalType => "Dog";
    }
}
