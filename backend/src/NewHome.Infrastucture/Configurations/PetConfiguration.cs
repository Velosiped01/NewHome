using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewHome.Domain.Pets.ValueObjects;
using NewHome.Domain.Pets;
using NewHome.Domain.Shared;
using NewHome.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace NewHome.Infrastucture.Configurations
{
    public class PetConfiguration: IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("_pet");
            
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(BasedConstants.MAX_SIMPLE_DATA_LENGTH);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(p => p.Value,
                value => PetId.CreateFromDB(value));

            builder.Property(p => p.Gender)
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasConversion(v => v.Value,
                value => Gender.CreateFromDB(value));

            builder.Property(p => p.PicturePath);

            builder.Property(p => p.Age)
               .IsRequired();

            builder.Property(p => p.Species)
                .IsRequired();

            builder.Property(p => p.Species)
                .HasConversion(v => v.Value,
                value => Species.CreateFromDB(value));

            builder.Property(p => p.Breed)
                .HasMaxLength(BasedConstants.MAX_SIMPLE_DATA_LENGTH);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(BasedConstants.MAX_BIG_TEXT_LENGTH);

            builder.Property(p => p.Health)
                .HasMaxLength(BasedConstants.MAX_SMALL_TEXT_LENGTH);

            builder.Property(p => p.Address)
                .HasMaxLength(BasedConstants.MAX_SMALL_TEXT_LENGTH)
                .IsRequired();

            builder.Property(p => p.Castration);

            builder.Property(p => p.Sheltered);

            builder.HasOne(p => p.Owner)
                .WithMany(o => o.UserPets)
                .HasForeignKey(p => p.OwnerId)
                .HasPrincipalKey(o => o.Id)
                .IsRequired();

                



                
        }
    }
}
