using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Models;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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

            builder.Entity<Uh>().ToTable("Uh");
            builder.Entity<Status>().ToTable("Status");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
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
                    var now = DateTime.Now;
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
    }
}
