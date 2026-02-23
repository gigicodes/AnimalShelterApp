namespace AnimalShelterApp.Models
{
    public class Cat : Animal
    {
        public override string AnimalType => "Cat";
        public bool IsIndoor { get; set; }
    }
}
