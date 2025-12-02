using System;
using System.Collections.Generic;
using System.Text;

namespace Dogs.Models
{
    public class Dog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DogImage? ImageUrl { get; private set; }
        public bool Adopted { get; set; }

        public Dog()
        {

        }
        public Dog(string name, DogImage? image)
        {
            Name = name;
            BirthDate = DateTime.Now;
            Adopted = false;
            ImageUrl = image;
        }
        public Dog(string name)
        {
            Name = name;
            BirthDate = DateTime.Now;
            Adopted = false;
        }
       
        public void setName(string name)
        {
            Name = name;
        }
        public void setBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
        public void setAdopted(Dog dog)
        {
            Adopted = !Adopted;
        }

    }
}
