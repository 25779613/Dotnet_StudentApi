// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApi.Modals.Context;

namespace StudentApi.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20210529170249_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("studentDetails")
                        .HasColumnType("text");

                    b.Property<string>("studentEmail")
                        .HasColumnType("text");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("studentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("studentID");

                    b.ToTable("students");
                });
#pragma warning restore 612, 618
        }
    }
}
