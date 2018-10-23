﻿using System;
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
        public int UhId { get; set; }
        public Uh Uh { get; set; }
        //link com tabela Departamentos
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        [Required, Display(Name = "Cartão aeroporto:", ShortName = "Cartão:")]
        public int NumCartao { get; set; }
        [Required, Display(Name = "Número portway:", ShortName = "Núm pw:")]
        public int NumPw { get; set; }
        [Required, MaxLength(150), Display(Name = "Nome:")]
        public string Nome { get; set; }

        //link com a tabela Funções
        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
        //link com a tabela Equipas
        public int EquipaId { get; set; }
        public Equipa Equipa { get; set; }
        //link com a tabela Categorias
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        //link com a tabela Horario (horário praticado)
        [Display(Name = "Horário Praticado:")]
        public int HorarioPraticadoId { get; set; }
        public Horario ColaboradorHorarioPraticadoId { get; set; }
        //link com a tabela Horario (Horário Contratado)
        [Display(Name = "Horário Contratado:")]
        public int HorarioContratadoId { get; set; }
        public Horario HorarioContratado { get; set; }

        [DataType(DataType.Date), Display(Name = "Data de Admissão:")]
        public DateTime DataAdmissão { get; set; }
        [DataType(DataType.Date), Display(Name = "Fim de contrato:")]
        public DateTime DataFim { get; set; }
        //link com a tabela contratos
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        //link com a tabela Status
        public int StatusId { get; set; }
        public Status Status { get; set; }

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