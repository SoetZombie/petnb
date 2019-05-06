using System;
using System.Collections.Generic;
using System.Text;

namespace petnb.DTL.Data.Models
{
    class Pet
    {
        //properties
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Difficulty { get; set; }
        public double Weight { get; set; }


        //Construtor
        public Pet(string name)
        {
            PetName = name;
        }

        public Pet(string name, int type, string breed, int age, double difficulty, double weight)
        {
            PetName = name;
            Type = type;
            Breed = breed;
            Age = age;
            Difficulty = difficulty;
            Weight = weight;
        }
    }
}
