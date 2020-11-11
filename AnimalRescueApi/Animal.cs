namespace AnimalRescueApi
{
    public class Animal
    {
        private string Name { get; set; }

        private string Description { get; set; }

        public Animal(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
