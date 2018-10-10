using MyWayRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Data
{
    public class DbInitializer
    {
        public static void Initialize(MywayDbContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Uhs.Any())
            {
                return;   // DB has been seeded
            }

            var uhs = new Uh[]
            {
                new Uh { IATA = "LIS", UhNome = "Lisboa", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null },
                new Uh { IATA = "OPO", UhNome = "Porto", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null },
                new Uh { IATA = "FAO", UhNome = "Faro", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null },
                new Uh { IATA = "FNC", UhNome = "Funchal", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null }
            };

            foreach (Uh u in uhs)
            {
                context.Uhs.Add(u);
            }
            context.SaveChanges();

            var statuses = new Status[]
            {
                new Status { Statuses = "Ativo", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null },
                new Status { Statuses = "Inativo", CreatedAt = DateTime.Now, CreatedBy = "SISTEMA", LastUpdatedAt = null, LastUpdatedBy = null }
            };

            foreach (Status s in statuses)
            {
                context.Statuses.Add(s);
            }
            context.SaveChanges();

        }
    }
}
