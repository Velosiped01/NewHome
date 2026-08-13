using CSharpFunctionalExtensions;
using NewHome.Domain.Pets.ValueObjects;
using NewHome.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NewHome.Domain.Users;
using NewHome.Domain.Users.UserValueObjects;

namespace NewHome.Domain.Pets
{
    public sealed class Pet : Shared.Entity<PetId>
    {
        //ef core
        private Pet(PetId id) : base(id)
        {
        }

        private Pet(PetId pet_id, string name, Gender gender,string picture, int age, Species species, string breed, string description, string health, string adress, bool castration, User owner) : base(pet_id)
        {
            Name = name;
            Gender = gender;
            PicturePath = picture;
            Age = age;
            Species = species;
            Breed = breed;
            Description = description;
            Health = health;
            Address = adress;
            Castration = castration;
            Owner = owner;
            OwnerId = owner.Id;
        }


        public string Name { get; private set; }

        public Gender Gender { get; private set; }

        public string PicturePath { get; private set; }

        public int Age { get; private set; }

        public Species Species { get; private set; }

        public string Breed { get; private set; }

        public string Description { get; private set; }

        public string Health { get; private set; }

        public string Address { get; private set; }

        public bool Castration { get; private set; } = false;

        public bool Sheltered { get; private set; } = false; 

        public User Owner { get ; private set; }

        public UserId OwnerId { get; private set; }

        public static Result<Pet> Create(PetId id, string name,Gender gender, string picture, int age, Species  species, string breed,string description, string health, string address, bool castration, User owner)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Pet>("Name is required");

            if (age < 0 || age > 50) return Result.Failure<Pet>("Invalid age");

            if (string.IsNullOrWhiteSpace(breed)) return Result.Failure<Pet>("Breed is required");

            if (string.IsNullOrWhiteSpace(description)) return Result.Failure<Pet>("Description is reqired");

            if (string.IsNullOrWhiteSpace(health)) return Result.Failure<Pet>("Choose the health status");

            if (string.IsNullOrWhiteSpace(address)) return Result.Failure<Pet>("Provide your address");

            var Pet = new Pet(id, name, gender, picture, age, species, breed, description, health, address, castration, owner);

            return Result.Success(Pet); 
        }

        public void SetPicture(string path)
        {
            PicturePath = path;
        }
        public void RemovePicture()
        {
            PicturePath = null;
        }

        public void ChangeOwner(User user)
        {
            Owner = user;
        }
       
    }
}
