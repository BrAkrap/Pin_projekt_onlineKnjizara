﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pin_projekt_onlineKnjizara.Data;

namespace Pin_projekt_onlineKnjizara.Migrations
{
    [DbContext(typeof(Pin_projekt_onlineKnjizaraContext))]
    partial class Pin_projekt_onlineKnjizaraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pin_projekt_onlineKnjizara.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("Pin_projekt_onlineKnjizara.Models.Knjiga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId");

                    b.Property<decimal>("Cijena");

                    b.Property<int>("Kolicina");

                    b.Property<string>("Naslov");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Knjige");
                });

            modelBuilder.Entity("Pin_projekt_onlineKnjizara.Models.Knjiga", b =>
                {
                    b.HasOne("Pin_projekt_onlineKnjizara.Models.Autor", "Autor")
                        .WithMany("Knjige")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
