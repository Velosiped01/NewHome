using CSharpFunctionalExtensions;
using NewHome.Domain.Pets.ValueObjects;
using NewHome.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewHome.Domain.Pets
{
    public class Pet : Entities<PetId>
    {
        public string Name { get;}

        public Gender Gender { get; }

        public int Age { get; private set; }

        public Species Species { get; private set; }

        public string Breed { get; private set; }

        public string Description { get; private set; }

        public string Health { get; private set; }

        public string Address { get; private set; }

        public bool Castration { get; private set; } = false;

        public bool Sheltered { get; private set; } = false; 

        public static Result<Pet> Create(PetId id, string name,Gender gender, int age, Species  species, string breed,string description, string health, string adress, bool castration)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Pet>("Name is required");

            if (age < 0 || age > 100) return Result.Failure<Pet>("Invalid age");

            if (string.IsNullOrWhiteSpace(breed)) return Result.Failure<Pet>("Breed is required");

            if (string.IsNullOrWhiteSpace(description)) return Result.Failure<Pet>("Description is reqired");

            if (string.IsNullOrWhiteSpace(health)) return Result.Failure<Pet>("Choose the health status");

            if (string.IsNullOrWhiteSpace(adress)) return Result.Failure<Pet>("Provide your address");

            var Pet = new Pet(id, name, gender, age, species, breed, description, health, adress, castration);

            return Result.Success(Pet); 
        }

        private Pet(PetId id): base(id)
        {
        }

        private Pet(PetId pet_id, string name,Gender gender, int age, Species species, string breed, string description, string health, string adress, bool castration) : base(pet_id)
        {
            Name=name;
            Gender=gender;
            Age=age;
            Species=species;
            Breed=breed;
            Description=description;
            Health=health;
            Address=adress;
            Castration=castration;
        }
    }
}
