using MyWayRazor.Models.Tabelas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    [Table("Colaborador")]
    public class Colaborador : IBaseEntity
    {
        [Key]
        public int ColaboradorID { get; set; }

        //link com tabela Uh (unidades de handling)
        [Display(Name ="Unidade de handling:", ShortName ="UH:")]
        public int UhId { get; set; }
        public Uh Uh { get; set; }
        //link com tabela Departamentos
        [Display(Name = "Departamento:", ShortName = "Dpto.:")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        [Required, Display(Name = "Cartão aeroporto:", ShortName = "Cartão:")]
        public int NumCartao { get; set; }
        [Required, Display(Name = "Número portway:", ShortName = "Núm pw:")]
        public int NumPw { get; set; }
        [Required, MaxLength(150), Display(Name = "Nome:")]
        public string Nome { get; set; }

        //link com a tabela Funções
        [Display(Name = "Funções:")]
        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
        //link com a tabela Equipas
        [Display(Name = "Equipas:")]
        public int EquipaId { get; set; }
        public Equipa Equipa { get; set; }
        //link com a tabela Categorias
        [Display(Name = "Categorias:", ShortName = "Cat.:")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        //link com a tabela Horario (horário praticado)
        [ForeignKey("HorarioPraticado"), Column(Order = 0), Display(Name = "Horário Praticado:")]
        public int? HorarioPraticadoId { get; set; }
        public virtual Horario HorarioPraticado { get; set; }
        //link com a tabela Horario (Horário Contratado)
        [ForeignKey("HorarioContratado"), Column(Order = 0), Display(Name = "Horário Contratado:")]
        public int? HorarioContratadoId { get; set; }
        public virtual Horario HorarioContratado { get; set; }

        [DataType(DataType.Date), Display(Name = "Data de Admissão:")]
        public DateTime DataAdmissao { get; set; }
        [DataType(DataType.Date), Display(Name = "Fim de contrato:")]
        public DateTime DataFim { get; set; }
        //link com a tabela contratos
        [Display(Name = "Contrato:")]
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        [Display(Name = "Ativo?:")]
        public bool Ativo { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }
    }
}