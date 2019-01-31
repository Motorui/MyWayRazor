﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWayRazor.Data;

namespace MyWayRazor.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190128184412_AssistenciasPRM")]
    partial class MigrationAssistenciasPRM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyWayRazor.Areas.Identity.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MyWayRazor.Areas.Identity.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyWayRazor.Areas.Identity.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("MyWayRazor.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("MyWayRazor.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<int>("ContratoId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DataAdmissão");

                    b.Property<DateTime>("DataFim");

                    b.Property<int>("DepartamentoId");

                    b.Property<int>("EquipaId");

                    b.Property<int>("FuncaoId");

                    b.Property<int?>("HorarioContratadoId");

                    b.Property<int?>("HorarioPraticadoId");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("NumCartao");

                    b.Property<int>("NumPw");

                    b.Property<int>("StatusId");

                    b.Property<int>("UhId");

                    b.HasKey("ColaboradorID");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ContratoId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("EquipaId");

                    b.HasIndex("FuncaoId");

                    b.HasIndex("HorarioContratadoId");

                    b.HasIndex("HorarioPraticadoId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UhId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("MyWayRazor.Models.Contrato", b =>
                {
                    b.Property<int>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContratoTipo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("ContratoId");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("MyWayRazor.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DepartamentoNome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("DepartamentoNumero");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("MyWayRazor.Models.Equipa", b =>
                {
                    b.Property<int>("EquipaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("EquipaNome")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("EquipaId");

                    b.ToTable("Equipa");
                });

            modelBuilder.Entity("MyWayRazor.Models.Funcao", b =>
                {
                    b.Property<int>("FuncaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("FuncaoNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("FuncaoId");

                    b.ToTable("Funcao");
                });

            modelBuilder.Entity("MyWayRazor.Models.Horario", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("HorarioHora");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.HasKey("HorarioId");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("MyWayRazor.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("Statuses")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("MyWayRazor.Models.Uh", b =>
                {
                    b.Property<int>("UhId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("IATA")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime?>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<string>("UhNome")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("UhId");

                    b.ToTable("Uh");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWayRazor.Areas.Identity.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Areas.Identity.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWayRazor.Models.Colaborador", b =>
                {
                    b.HasOne("MyWayRazor.Models.Categoria", "Categoria")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Contrato", "Contrato")
                        .WithMany("Colaboradores")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Departamento", "Departamento")
                        .WithMany("Colaboradores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Equipa", "Equipa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EquipaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Funcao", "Funcao")
                        .WithMany("Colaboradores")
                        .HasForeignKey("FuncaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Horario", "HorarioContratado")
                        .WithMany()
                        .HasForeignKey("HorarioContratadoId");

                    b.HasOne("MyWayRazor.Models.Horario", "HorarioPraticado")
                        .WithMany()
                        .HasForeignKey("HorarioPraticadoId");

                    b.HasOne("MyWayRazor.Models.Status", "Status")
                        .WithMany("Colaboradores")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWayRazor.Models.Uh", "Uh")
                        .WithMany("Colaboradores")
                        .HasForeignKey("UhId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}