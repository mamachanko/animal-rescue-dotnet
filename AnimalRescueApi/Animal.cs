using System;
using System.Collections.Generic;

namespace AnimalRescueApi
{
    public class Animal
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Animal {nameof(Name)}: {Name}, {nameof(Description)}: {Description}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Animal) obj);
        }

        private bool Equals(Animal other)
        {
            return Name == other.Name && Description == other.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description);
        }
    }
}
