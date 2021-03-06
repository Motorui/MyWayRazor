﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models.Tabelas;
using System;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Contratos
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contrato Contrato { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contrato.ContratoTipo = Request.Form["Contrato.ContratoTipo"].ToString().ToUpper();
            Contrato.CreatedAt = DateTime.UtcNow.Date;
            Contrato.CreatedBy = User.Identity.Name.ToString();
            _context.Contratos.Add(Contrato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}