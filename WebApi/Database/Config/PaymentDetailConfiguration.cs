using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Infrastructure.Models;

namespace WebApi.Database.Config
{
    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            // builder.Property(m => m.Title)
            //     .IsRequired()
            //     .HasMaxLength(60)
            //     .HasAnnotation("MinLength", 3);

            // builder.Property(m => m.Price)
            //     .HasColumnType("decimal(18,2)");

            // builder.Property(m => m.Genre)
            //     .HasMaxLength(30)
            //     .HasAnnotation("RegularExpression", @"^[A-Z]+[a-zA-Z""'\s-]*$")
            //     .IsRequired();

            // builder.Property(m => m.Rating)
            //     .HasMaxLength(5)
            //     .HasAnnotation("RegularExpression", @"^[A-Z]+[a-zA-Z0-9""'\s-]*$")
            //     .IsRequired();
        }
    }
}