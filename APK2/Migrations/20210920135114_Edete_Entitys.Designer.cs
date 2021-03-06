// <auto-generated />
using System;
using APK2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APK2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210920135114_Edete_Entitys")]
    partial class Edete_Entitys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("APK2.Entitys.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BIK")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<int?>("CounterpartyId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("KorShet")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NameBank")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RsShet")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimSpan")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CounterpartyId");

                    b.HasIndex("StatusId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("APK2.Entitys.Counterparty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("KPP")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OGRN")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("OKPO")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeSpan")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Counterparty");
                });

            modelBuilder.Entity("APK2.Entitys.DocumentsIndividual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOffAction")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("longtext");

                    b.Property<bool>("DocUl")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<int?>("IndividualId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("longtext");

                    b.Property<string>("Series")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("time(6)");

                    b.Property<int?>("TypeDocId")
                        .HasColumnType("int");

                    b.Property<string>("WhoIssued")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeDocId");

                    b.ToTable("DocumentsIndividual");
                });

            modelBuilder.Entity("APK2.Entitys.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdmission")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateDismissal")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TabNamber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("StatusId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("APK2.Entitys.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameGroup")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TableGroup")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("APK2.Entitys.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Inn")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Patpatronymic")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Snils")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StatusId");

                    b.ToTable("Individual");
                });

            modelBuilder.Entity("APK2.Entitys.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("NamePost")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("APK2.Entitys.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("APK2.Entitys.TypeDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameType")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TableType")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("TypeDoc");
                });

            modelBuilder.Entity("APK2.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LoginUser")
                        .HasColumnType("longtext");

                    b.Property<string>("NameUser")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("APK2.Entitys.Account", b =>
                {
                    b.HasOne("APK2.Entitys.Counterparty", "Counterparty")
                        .WithMany()
                        .HasForeignKey("CounterpartyId");

                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Counterparty");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.Counterparty", b =>
                {
                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.DocumentsIndividual", b =>
                {
                    b.HasOne("APK2.Entitys.Individual", null)
                        .WithMany("Documents")
                        .HasForeignKey("IndividualId");

                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("APK2.Entitys.TypeDoc", "TypeDoc")
                        .WithMany()
                        .HasForeignKey("TypeDocId");

                    b.Navigation("Status");

                    b.Navigation("TypeDoc");
                });

            modelBuilder.Entity("APK2.Entitys.Employee", b =>
                {
                    b.HasOne("APK2.Entitys.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Post");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.Group", b =>
                {
                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.Individual", b =>
                {
                    b.HasOne("APK2.Entitys.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Group");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.Post", b =>
                {
                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.TypeDoc", b =>
                {
                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.User", b =>
                {
                    b.HasOne("APK2.Entitys.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("APK2.Entitys.Individual", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
