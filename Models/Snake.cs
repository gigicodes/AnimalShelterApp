namespace AnimalShelterApp.Models
{
    public class Snake : Animal
    {
        public override string AnimalType => "Snake";
        public bool IsVenomous { get; set; }
        public string Specie { get; set; } = string.Empty;
    }
}
