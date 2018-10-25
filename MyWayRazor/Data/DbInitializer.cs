using System;
using System.Linq;
using MyWayRazor.Models;

namespace MyWayRazor.Data
{
    public class DbInitializer
    {
        public static void Initialize(MywayDbContext context)
        {
            SeedCategorias(context);
            SeedContratos(context);
            SeedDepartamentos(context);
            SeedEquipas(context);
            SeedFuncoes(context);
            SeedHorarios(context);
            SeedStatuses(context);
            SeedUhs(context);
        }
        public static void SeedCategorias(MywayDbContext context)
        {
            if (!context.Categorias.Any(c => c.CategoriaNome == "ASSISTENTE A PASSAGEIROS DE MOBILIDADE REDUZIDA"))
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = "ASSISTENTE A PASSAGEIROS DE MOBILIDADE REDUZIDA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Categorias.Add(categoria);
                context.SaveChanges();
            }

            if (!context.Categorias.Any(c => c.CategoriaNome == "TECNICO TRAFEGO ASSISTENCIA ESCALA"))
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = "TECNICO TRAFEGO ASSISTENCIA ESCALA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Categorias.Add(categoria);
                context.SaveChanges();
            }

            if (!context.Categorias.Any(c => c.CategoriaNome == "OPERADOR ASSISTENCIA ESCALA"))
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = "OPERADOR ASSISTENCIA ESCALA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Categorias.Add(categoria);
                context.SaveChanges();
            }

            if (!context.Categorias.Any(c => c.CategoriaNome == "TECNICO"))
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = "TECNICO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Categorias.Add(categoria);
                context.SaveChanges();
            }

        }

        public static void SeedContratos(MywayDbContext context)
        {
            if (!context.Contratos.Any(c => c.ContratoTipo == "PERMANENTE"))
            {
                Contrato contrato = new Contrato
                {
                    ContratoTipo = "PERMANENTE",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Contratos.Add(contrato);
                context.SaveChanges();
            }

            if (!context.Contratos.Any(c => c.ContratoTipo == "TERMO CERTO"))
            {
                Contrato contrato = new Contrato
                {
                    ContratoTipo = "TERMO CERTO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Contratos.Add(contrato);
                context.SaveChanges();
            }

            if (!context.Contratos.Any(c => c.ContratoTipo == "TERMO INCERTO"))
            {
                Contrato contrato = new Contrato
                {
                    ContratoTipo = "TERMO INCERTO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Contratos.Add(contrato);
                context.SaveChanges();
            }

            if (!context.Contratos.Any(c => c.ContratoTipo == "MULTITEMPO"))
            {
                Contrato contrato = new Contrato
                {
                    ContratoTipo = "MULTITEMPO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Contratos.Add(contrato);
                context.SaveChanges();
            }
        }

        public static void SeedDepartamentos(MywayDbContext context)
        {
            if (!context.Departamentos.Any(d => d.DepartamentoNumero == 71680))
            {
                Departamento departamento = new Departamento
                {
                    DepartamentoNumero = 71680,
                    DepartamentoNome = "Lisboa - PMRs",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Departamentos.Add(departamento);
                context.SaveChanges();
            }
        }

        public static void SeedEquipas(MywayDbContext context)
        {
            if (!context.Equipas.Any(e => e.EquipaNome == "N/A"))
            {
                Equipa equipa = new Equipa
                {
                    EquipaNome = "N/A",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Equipas.Add(equipa);
                context.SaveChanges();
            }

            if (!context.Equipas.Any(e => e.EquipaNome == "A"))
            {
                Equipa equipa = new Equipa
                {
                    EquipaNome = "A",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Equipas.Add(equipa);
                context.SaveChanges();
            }

            if (!context.Equipas.Any(e => e.EquipaNome == "B"))
            {
                Equipa equipa = new Equipa
                {
                    EquipaNome = "B",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Equipas.Add(equipa);
                context.SaveChanges();
            }

            if (!context.Equipas.Any(e => e.EquipaNome == "C"))
            {
                Equipa equipa = new Equipa
                {
                    EquipaNome = "C",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Equipas.Add(equipa);
                context.SaveChanges();
            }

        }

        public static void SeedFuncoes(MywayDbContext context)
        {
            if (!context.Funcoes.Any(f => f.FuncaoNome == "COORDENADOR"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "COORDENADOR",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "ASSISTENTE ADMINISTRATIVA"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "ASSISTENTE ADMINISTRATIVA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "SUPERVISOR"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "SUPERVISOR",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "ALOCADOR"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "ALOCADOR",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "ASSISTENTE PMR"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "ASSISTENTE PMR",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "ASSISTENTE PMR PART-TIME"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "ASSISTENTE PMR PART-TIME",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "MOTORISTA"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "MOTORISTA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "MOTORISTA AMBULIFT"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "MOTORISTA AMBULIFT",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "PLANEAMENTO"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "PLANEAMENTO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }

            if (!context.Funcoes.Any(f => f.FuncaoNome == "QUALIDADE"))
            {
                Funcao funcao = new Funcao
                {
                    FuncaoNome = "QUALIDADE",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Funcoes.Add(funcao);
                context.SaveChanges();
            }
        }

        public static void SeedHorarios(MywayDbContext context)
        {
            if (!context.Horarios.Any(h => h.HorarioHora == 40))
            {
                Horario horario = new Horario
                {
                    HorarioHora = 40,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Horarios.Add(horario);
                context.SaveChanges();
            }

            if (!context.Horarios.Any(h => h.HorarioHora == 38))
            {
                Horario horario = new Horario
                {
                    HorarioHora = 38,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Horarios.Add(horario);
                context.SaveChanges();
            }

            if (!context.Horarios.Any(h => h.HorarioHora == 25))
            {
                Horario horario = new Horario
                {
                    HorarioHora = 25,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Horarios.Add(horario);
                context.SaveChanges();
            }
        }

        public static void SeedStatuses(MywayDbContext context)
        {
            if(!context.Statuses.Any(s => s.Statuses == "ATIVO"))
            {
                Status status = new Status
                {
                    Statuses = "ATIVO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Statuses.Add(status);
                context.SaveChanges();
            }

            if (!context.Statuses.Any(s => s.Statuses == "INATIVO"))
            {
                Status status = new Status
                {
                    Statuses = "INATIVO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Statuses.Add(status);
                context.SaveChanges();
            }

        }

        public static void SeedUhs(MywayDbContext context)
        {
            if (!context.Uhs.Any(u => u.IATA == "LIS"))
            {
                Uh uh = new Uh
                {
                    IATA = "LIS",
                    UhNome = "LISBOA",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Uhs.Add(uh);
                context.SaveChanges();
            }

            if (!context.Uhs.Any(u => u.IATA == "OPO"))
            {
                Uh uh = new Uh
                {
                    IATA = "OPO",
                    UhNome = "PORTO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Uhs.Add(uh);
                context.SaveChanges();
            }

            if (!context.Uhs.Any(u => u.IATA == "FAO"))
            {
                Uh uh = new Uh
                {
                    IATA = "FAO",
                    UhNome = "FARO",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Uhs.Add(uh);
                context.SaveChanges();
            }

            if (!context.Uhs.Any(u => u.IATA == "FNC"))
            {
                Uh uh = new Uh
                {
                    IATA = "FNC",
                    UhNome = "FUNCHAL",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Sistema",
                    LastUpdatedAt = null,
                    LastUpdatedBy = null
                };

                context.Uhs.Add(uh);
                context.SaveChanges();
            }
        }
    }
}