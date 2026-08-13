using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewHome.Domain.Shared;
using NewHome.Domain.UserData.Evaluation.EvaluationVO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.InteropServices;

namespace NewHome.Infrastucture.Configurations
{
    internal class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("_evaluations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(i => i.Value,
                value => EvaluationId.CreateFromDB(value));

            builder.HasOne(e => e.User)
               .WithMany(u => u.UserEvaluations)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Comment)
                .IsRequired()
                .HasMaxLength(BasedConstants.MAX_BIG_TEXT_LENGTH);

            builder.Property(e => e.RatingValue)
                .IsRequired();

            builder.Property(e => e.Date)
                .IsRequired();
                
        }
    }
}
