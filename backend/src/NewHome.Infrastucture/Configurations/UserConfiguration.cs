using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using NewHome.Domain.Pets;
using NewHome.Domain.Shared;
using NewHome.Domain.Users;
using NewHome.Domain.Users.UserValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Infrastucture.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasConversion(
                    id => id.Value, 
                        value => UserId.CreateFromDB(value));

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(BasedConstants.MAX_SIMPLE_DATA_LENGTH);

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(BasedConstants.MAX_SIMPLE_DATA_LENGTH);

            builder.Property(u => u.PhoneNumber)
                .HasConversion(
                    pn => pn.Value,
                    value => PhoneNumber.CreateFromDB(value));


            builder.Property(u => u.Raiting)
                .HasConversion(
                    rt => rt.Value,
                    value => Rating.CreateFromDB(value));


            builder.Property(u => u.PicturePath);


        }
    }
}
