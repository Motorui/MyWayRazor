﻿using MyWayRazor.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models.Tabelas
{
    [Table("Categoria")]
    public class Categoria : IBaseEntity
    {
        [Key]
        public int CategoriaId { get; set; }

        string _categoriaNome;
        [Required, MaxLength(50), Display(Name = "Categoria:", ShortName = "Cat:")]
        public string CategoriaNome
        {
            get => _categoriaNome;
            set => _categoriaNome = value.ToUpper();
        }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}