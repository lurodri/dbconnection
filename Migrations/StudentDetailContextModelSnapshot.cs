// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using api_aurora.Models;

namespace api_aurora.Migrations
{
    [DbContext(typeof(StudentDetailContext))]
    partial class StudentDetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_aurora.Models.StudentDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Birth_Date")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("ID");

                    b.ToTable("StudentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
