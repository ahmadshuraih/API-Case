// <auto-generated />
using API_Case.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Case.Migrations
{
    [DbContext(typeof(SqliteDBContext))]
    partial class SqliteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API_Case.Model.AdresGegevens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Huisnummer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LandCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Plaats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AdresGegevens", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
