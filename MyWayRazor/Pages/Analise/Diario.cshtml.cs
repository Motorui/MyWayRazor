﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.Analise
{
    public class DiarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DiarioModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssistenciasPRM> AssistenciasPRM { get; set; }

        public async Task OnGetAsync()
        {
            AssistenciasPRM = await _context.AssistenciasPRMS.ToListAsync();
        }
    }
}