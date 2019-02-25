using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Models;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Staging;
using MyWayRazor.Models.Tabelas;
using MyWayRazor.Models.ToDoList;
using Newtonsoft.Json;

namespace MyWayRazor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment env;
        private readonly string folderName = "Data/SeedData";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment environment)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            env = environment;
        }

        #region set DbSet

        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        //public DbSet<Assistencia> Assistencias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        //public DbSet<DadosPessoais> DadosPessoais { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        //public DbSet<Email> Emails { get; set; }
        public DbSet<Equipa> Equipas { get; set; }
        //public DbSet<Formacao> Formacoes { get; set; }
        //public DbSet<FormacaoColaborador> FormacoesColaboradores { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        //public DbSet<Observacao> Observacoes { get; set; }
        //public DbSet<Resumo> Resumos { get; set; }
        //public DbSet<Sla> Slas { get; set; }
        public DbSet<Status> Statuses { get; set; }
        //public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Uh> Uhs { get; set; }
        public DbSet<AssistenciasPRM> AssistenciasPRMS { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Stand> Stands { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Porta> Portas { get; set; }
        public DbSet<Staging> Stagings { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Stand>()
                .HasIndex(s => s.StandN)
                .IsUnique();

            #region Seed Data
            // Seed Categorias
            var CategoriasFile = Path.Combine(env.ContentRootPath, folderName, "Categorias.json");
            var CategoriasStream = File.Open(CategoriasFile, FileMode.Open, FileAccess.Read);
            var CategoriasReader = new StreamReader(CategoriasStream);
            var categorias = JsonConvert.DeserializeObject<List<Categoria>>(CategoriasReader.ReadToEnd());
            builder.Entity<Categoria>().HasData(categorias);

            // Seed Portas de Embarque
            var PortasFile = Path.Combine(env.ContentRootPath, folderName, "Portas.json");
            var PortasStream = File.Open(PortasFile, FileMode.Open, FileAccess.Read);
            var PortasReader = new StreamReader(PortasStream);
            var portas = JsonConvert.DeserializeObject<List<Porta>>(PortasReader.ReadToEnd());
            builder.Entity<Porta>().HasData(portas);

            // Seed Statuses
            var StatusesFile = Path.Combine(env.ContentRootPath, folderName, "Statuses.json");
            var StatusesStream = File.Open(StatusesFile, FileMode.Open, FileAccess.Read);
            var StatusesReader = new StreamReader(StatusesStream);
            var statuses = JsonConvert.DeserializeObject<List<Status>>(StatusesReader.ReadToEnd());
            builder.Entity<Status>().HasData(statuses);

            // Seed Colaboradores
            var ColaboradoresFile = Path.Combine(env.ContentRootPath, folderName, "Colaboradores.json");
            var ColaboradoresStream = File.Open(ColaboradoresFile, FileMode.Open, FileAccess.Read);
            var ColaboradoresReader = new StreamReader(ColaboradoresStream);
            var colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(ColaboradoresReader.ReadToEnd());
            builder.Entity<Colaborador>().HasData(colaboradores);

            // Seed Contratos
            var ContratosFile = Path.Combine(env.ContentRootPath, folderName, "Contratos.json");
            var ContratosStream = File.Open(ContratosFile, FileMode.Open, FileAccess.Read);
            var ContratosReader = new StreamReader(ContratosStream);
            var contratos = JsonConvert.DeserializeObject<List<Contrato>>(ContratosReader.ReadToEnd());
            builder.Entity<Contrato>().HasData(contratos);

            // Seed Departamentos
            var DepartamentosFile = Path.Combine(env.ContentRootPath, folderName, "Departamentos.json");
            var DepartamentosStream = File.Open(DepartamentosFile, FileMode.Open, FileAccess.Read);
            var DepartamentosReader = new StreamReader(DepartamentosStream);
            var departamentos = JsonConvert.DeserializeObject<List<Departamento>>(DepartamentosReader.ReadToEnd());
            builder.Entity<Departamento>().HasData(departamentos);

            // Seed Equipas
            var EquipasFile = Path.Combine(env.ContentRootPath, folderName, "Equipas.json");
            var EquipasStream = File.Open(EquipasFile, FileMode.Open, FileAccess.Read);
            var EquipasReader = new StreamReader(EquipasStream);
            var equipas = JsonConvert.DeserializeObject<List<Equipa>>(EquipasReader.ReadToEnd());
            builder.Entity<Equipa>().HasData(equipas);

            // Seed Funções
            var FuncoesFile = Path.Combine(env.ContentRootPath, folderName, "Funcoes.json");
            var FuncoesStream = File.Open(FuncoesFile, FileMode.Open, FileAccess.Read);
            var FuncoesReader = new StreamReader(FuncoesStream);
            var funcoes = JsonConvert.DeserializeObject<List<Funcao>>(FuncoesReader.ReadToEnd());
            builder.Entity<Funcao>().HasData(funcoes);

            // Seed Horários
            var HorariosFile = Path.Combine(env.ContentRootPath, folderName, "Horarios.json");
            var HorariosStream = File.Open(HorariosFile, FileMode.Open, FileAccess.Read);
            var HorariosReader = new StreamReader(HorariosStream);
            var horarios = JsonConvert.DeserializeObject<List<Horario>>(HorariosReader.ReadToEnd());
            builder.Entity<Horario>().HasData(horarios);

            // Seed Plataformas
            var PlataformasFile = Path.Combine(env.ContentRootPath, folderName, "Plataformas.json");
            var PlataformasStream = File.Open(PlataformasFile, FileMode.Open, FileAccess.Read);
            var PlataformasReader = new StreamReader(PlataformasStream);
            var plataformas = JsonConvert.DeserializeObject<List<Plataforma>>(PlataformasReader.ReadToEnd());
            builder.Entity<Plataforma>().HasData(plataformas);

            // Seed Unidades de handling
            var UhsFile = Path.Combine(env.ContentRootPath, folderName, "Uhs.json");
            var UhsStream = File.Open(UhsFile, FileMode.Open, FileAccess.Read);
            var UhsReader = new StreamReader(UhsStream);
            var uhs = JsonConvert.DeserializeObject<List<Uh>>(UhsReader.ReadToEnd());
            builder.Entity<Uh>().HasData(uhs);

            // Seed Stands
            var StandsFile = Path.Combine(env.ContentRootPath, folderName, "Stands.json");
            var StandsStream = File.Open(StandsFile, FileMode.Open, FileAccess.Read);
            var StandsReader = new StreamReader(StandsStream);
            var stands = JsonConvert.DeserializeObject<List<Stand>>(StandsReader.ReadToEnd());
            builder.Entity<Stand>().HasData(stands);

            #endregion
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IBaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    var user = "";
                    try
                    {
                        user = _httpContextAccessor.HttpContext.User.Identity.Name;
                    }
                    catch (NullReferenceException ex)
                    {
                        var erro = ex;
                        user = "SISTEMA";
                    }


                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            baseEntity.LastUpdatedAt = now;
                            baseEntity.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            baseEntity.CreatedAt = now;
                            baseEntity.CreatedBy = user;
                            baseEntity.LastUpdatedAt = null;
                            baseEntity.LastUpdatedBy = null;
                            break;
                    }
                }
            }
        }
    }
}
