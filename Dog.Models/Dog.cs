using System;
using System.Collections.Generic;
using System.Text;

namespace Dog.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DogImage? ImageUrl { get; set; }
        public bool Adopted { get; set; }


        public Dog(string name, DogImage? image)
        {
            BirthDate = DateTime.Now;
            Adopted = false;
            ImageUrl = image;
        }
        public Dog(string Name)
        {
            BirthDate = DateTime.Now;
            Adopted = false;
        }
        public override string ToString()
        {
            return $"{Name} (ID: {Id}), Born on: {BirthDate.ToShortDateString()}, Adopted: {Adopted}, Image URL: {ImageUrl?.Message ?? "No Image"}";
        }
    }
}
