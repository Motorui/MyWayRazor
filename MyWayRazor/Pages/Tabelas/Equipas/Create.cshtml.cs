﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Equipas
{
    public class CreateModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public CreateModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Equipa Equipa { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Equipa.EquipaNome = Request.Form["Equipa.EquipaNome"].ToString().ToUpper();
            Equipa.CreatedAt = DateTime.Now.Date;
            Equipa.CreatedBy = User.Identity.Name.ToString();
            _context.Equipas.Add(Equipa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}