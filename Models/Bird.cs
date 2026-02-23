namespace AnimalShelterApp.Models
{
    public class Bird : Animal
    {
        public override string AnimalType => "Bird";
        public bool CanTalk { get; set; }
        public string Breed { get; set; } = string.Empty;
    }
}
