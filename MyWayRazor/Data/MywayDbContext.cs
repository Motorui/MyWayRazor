using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models;

namespace MyWayRazor.Data
{
    public class MywayDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MywayDbContext(DbContextOptions<MywayDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Assistencia> Assistencias { get; set; }
        public DbSet<BolsaHoras> BolsasHoras { get; set; }
        public DbSet<CargaHoraria> CargasHorarias { get; set; }
        public DbSet<CentroCusto> CentrosCusto { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<DadosPessoais> DadosPessoais { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<FormacaoColaborador> FormacoesColaboradores { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }
        public DbSet<Resumo> Resumos { get; set; }
        public DbSet<Sla> Slas { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Uh> Uhs { get; set; }
        public DbSet<VinculoLaboral> VinculosLaborais { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uh>().ToTable("Uh");
            modelBuilder.Entity<Status>().ToTable("Status");
        }

    }

}
