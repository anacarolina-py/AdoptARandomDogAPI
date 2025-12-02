using System;
using System.Collections.Generic;
using System.Text;

namespace Dogs.Models
{
    public class Tutor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public int DogId { get; private set; }

        public Tutor()
        {
        }
        public Tutor(string name, string phone, string email, int dogId)
        {
            Name = name;
            Phone = phone;
            Email = email;
            DogId = dogId;
        }
    }
}
