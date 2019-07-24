using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Models;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Calendario;
using MyWayRazor.Models.Colaboradores;
using MyWayRazor.Models.Formacoes;
using MyWayRazor.Models.Staging;
using MyWayRazor.Models.Tabelas;
using MyWayRazor.Models.ToDoList;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<FormacaoColaborador> FormacoesColaboradores { get; set; }
        public DbSet<HistoricoFormacaoColaborador> HistoricoFormacoesColaboradores { get; set; }
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
        public DbSet<Pier> Piers { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Porta> Portas { get; set; }
        public DbSet<Staging> Stagings { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<DadosAeroporto> DadosAeroportos { get; set; }
        public DbSet<HistoricoAssistencia> HistoricoAssistencias { get; set; }
        public DbSet<Formador> Formadores { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Calendario> Calendarios { get; set; }

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

            builder.Entity<AssistenciasPRM>()
                .Property(s => s.Stand)
                .HasDefaultValue(000);

            #region Calendario
            builder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.DateKey);

                entity.Property(e => e.DateKey).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DaySuffix)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DowinMonth).HasColumnName("DOWInMonth");

                entity.Property(e => e.FirstDayOfMonth).HasColumnType("date");

                entity.Property(e => e.FirstDayOfNextMonth).HasColumnType("date");

                entity.Property(e => e.FirstDayOfNextYear).HasColumnType("date");

                entity.Property(e => e.FirstDayOfQuarter).HasColumnType("date");

                entity.Property(e => e.FirstDayOfYear).HasColumnType("date");

                entity.Property(e => e.HolidayText)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IsoweekOfYear).HasColumnName("ISOWeekOfYear");

                entity.Property(e => e.LastDayOfMonth).HasColumnType("date");

                entity.Property(e => e.LastDayOfQuarter).HasColumnType("date");

                entity.Property(e => e.LastDayOfYear).HasColumnType("date");

                entity.Property(e => e.Mmyyyy)
                    .IsRequired()
                    .HasColumnName("MMYYYY")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonthYear)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.QuarterName)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
            #endregion

            #region Colaborador

            builder.Entity<Colaborador>()
            .HasIndex(c => c.Nome)
            .HasName("AlternateKey_Nome")
            .IsUnique();

            #endregion

            #region Formacao

            builder.Entity<Formacao>()
            .HasIndex(c => c.FormacaoNome)
            .HasName("AlternateKey_Nome")
            .IsUnique();

            builder.Entity<Formacao>()
            .HasIndex(c => c.FormacaoCod)
            .HasName("AlternateKey_Cod")
            .IsUnique();

            builder.Entity<Formacao>().HasData(new[]{
                   new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "BÁSICO DE PMR",
                    FormacaoCod = "BPMR",
                    FormacaoValidade = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                    new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "RAMP SAFETY",
                    FormacaoCod = "RS",
                    FormacaoValidade = 3,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                     new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "SEGURANÇA NÍVEL 13",
                    FormacaoCod = "SEC.13",
                    FormacaoValidade = 3,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                      new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "DANGEROUS GOODS CAT.9",
                    FormacaoCod = "DGR CAT.9",
                    FormacaoValidade = 2,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                       new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "HUMAN FACTOR",
                    FormacaoCod = "HF",
                    FormacaoValidade = 3,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                        new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "SAÚDE E SEGURANÇA NO TRABALHO",
                    FormacaoCod = "SST",
                    FormacaoValidade = 3,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                         new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "ESCOLA NACIONAL DE BOMBEIROS",
                    FormacaoCod = "ENB",
                    FormacaoValidade = 2,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   },
                          new Formacao {
                    FormacaoId = Guid.NewGuid(),
                    FormacaoNome = "GSE AMBULIFTS",
                    FormacaoCod = "GSE",
                    FormacaoValidade = 3,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "SISTEMA"
                   }
                });

            #endregion

            #region Seed Data
            // Seed Categorias
            var CategoriasFile = Path.Combine(env.ContentRootPath, folderName, "Categorias.json");
            var CategoriasStream = File.Open(CategoriasFile, FileMode.Open, FileAccess.Read);
            var CategoriasReader = new StreamReader(CategoriasStream);
            var categorias = JsonConvert.DeserializeObject<List<Categoria>>(CategoriasReader.ReadToEnd());
            builder.Entity<Categoria>().HasData(categorias);

            // Seed Statuses
            var StatusesFile = Path.Combine(env.ContentRootPath, folderName, "Statuses.json");
            var StatusesStream = File.Open(StatusesFile, FileMode.Open, FileAccess.Read);
            var StatusesReader = new StreamReader(StatusesStream);
            var statuses = JsonConvert.DeserializeObject<List<Status>>(StatusesReader.ReadToEnd());
            builder.Entity<Status>().HasData(statuses);

            // Seed Colaboradores
            //var ColaboradoresFile = Path.Combine(env.ContentRootPath, folderName, "Colaboradores.json");
            //var ColaboradoresStream = File.Open(ColaboradoresFile, FileMode.Open, FileAccess.Read);
            //var ColaboradoresReader = new StreamReader(ColaboradoresStream);
            //var colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(ColaboradoresReader.ReadToEnd());
            //builder.Entity<Colaborador>().HasData(colaboradores);

            // Seed Contratos
            //var ContratosFile = Path.Combine(env.ContentRootPath, folderName, "Contratos.json");
            //var ContratosStream = File.Open(ContratosFile, FileMode.Open, FileAccess.Read);
            //var ContratosReader = new StreamReader(ContratosStream);
            //var contratos = JsonConvert.DeserializeObject<List<Contrato>>(ContratosReader.ReadToEnd());
            //builder.Entity<Contrato>().HasData(contratos);

            // Seed Departamentos
            //var DepartamentosFile = Path.Combine(env.ContentRootPath, folderName, "Departamentos.json");
            //var DepartamentosStream = File.Open(DepartamentosFile, FileMode.Open, FileAccess.Read);
            //var DepartamentosReader = new StreamReader(DepartamentosStream);
            //var departamentos = JsonConvert.DeserializeObject<List<Departamento>>(DepartamentosReader.ReadToEnd());
            //builder.Entity<Departamento>().HasData(departamentos);

            // Seed Equipas
            var EquipasFile = Path.Combine(env.ContentRootPath, folderName, "Equipas.json");
            var EquipasStream = File.Open(EquipasFile, FileMode.Open, FileAccess.Read);
            var EquipasReader = new StreamReader(EquipasStream);
            var equipas = JsonConvert.DeserializeObject<List<Equipa>>(EquipasReader.ReadToEnd());
            builder.Entity<Equipa>().HasData(equipas);

            // Seed Funções
            //var FuncoesFile = Path.Combine(env.ContentRootPath, folderName, "Funcoes.json");
            //var FuncoesStream = File.Open(FuncoesFile, FileMode.Open, FileAccess.Read);
            //var FuncoesReader = new StreamReader(FuncoesStream);
            //var funcoes = JsonConvert.DeserializeObject<List<Funcao>>(FuncoesReader.ReadToEnd());
            //builder.Entity<Funcao>().HasData(funcoes);

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

            // Seed Portas de Embarque
            var PortasFile = Path.Combine(env.ContentRootPath, folderName, "Portas.json");
            var PortasStream = File.Open(PortasFile, FileMode.Open, FileAccess.Read);
            var PortasReader = new StreamReader(PortasStream);
            var portas = JsonConvert.DeserializeObject<List<Porta>>(PortasReader.ReadToEnd());
            builder.Entity<Porta>().HasData(portas);

            //Seed Piers
            var PiersFile = Path.Combine(env.ContentRootPath, folderName, "Piers.json");
            var PiersStream = File.Open(PiersFile, FileMode.Open, FileAccess.Read);
            var PiersReader = new StreamReader(PiersStream);
            var piers = JsonConvert.DeserializeObject<List<Pier>>(PiersReader.ReadToEnd());
            builder.Entity<Pier>().HasData(piers);

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

            // Seed Params
            var ParamFile = Path.Combine(env.ContentRootPath, folderName, "Parametros.json");
            var ParamStream = File.Open(ParamFile, FileMode.Open, FileAccess.Read);
            var ParamReader = new StreamReader(ParamStream);
            var parametros = JsonConvert.DeserializeObject<List<Parametro>>(ParamReader.ReadToEnd());
            builder.Entity<Parametro>().HasData(parametros);

            // Seed Formações
            //var FormacaoFile = Path.Combine(env.ContentRootPath, folderName, "Formacoes.json");
            //var FormacaoStream = File.Open(FormacaoFile, FileMode.Open, FileAccess.Read);
            //var FormacaoReader = new StreamReader(FormacaoStream);
            //var formacoes = JsonConvert.DeserializeObject<List<Formacao>>(FormacaoReader.ReadToEnd());
            //builder.Entity<Formacao>().HasData(parametros);

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
