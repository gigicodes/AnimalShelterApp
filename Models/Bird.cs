namespace AnimalShelterApp.Models
{
    public class Bird : Animal
    {
        public override string AnimalType => "Bird";
        public bool CanTalk { get; set; }
        public string Variety { get; set; } = string.Empty;
    }
}
