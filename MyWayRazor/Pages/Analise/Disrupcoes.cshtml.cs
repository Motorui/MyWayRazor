using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Analise
{
    [Breadcrumb("Disrupções", FromPage = typeof(IndexModel))]
    public class DisrupcoesModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DisrupcoesModel(ApplicationDbContext context)
        {
            db = context;
        }

        public int TotalVoosDia { get; private set; }
        public int TotalVoosComAssistencia { get; private set; }
        public int TotalDisrupcoes { get; private set; }
        public int TotalAssistenciasDisrupcoes { get; private set; }
        public int TotalPMRDisrupcoes { get; private set; }
        public DateTime SelectedDate { get; set; }
        public void OnGet()
        {

            SelectedDate = db.DadosAeroportos.OrderByDescending(d => d.ScheduleTimeUTC).FirstOrDefault().ScheduleTimeUTC.Value;

            TotalVoosDia = VoosDia(SelectedDate, SelectedDate);
            TotalVoosComAssistencia = VoosComAssistencia(SelectedDate, SelectedDate);

            TotalDisrupcoes = Disrupcoes(SelectedDate, SelectedDate);
            TotalAssistenciasDisrupcoes = AssistenciasDisrupcoes(SelectedDate, SelectedDate);
            TotalPMRDisrupcoes = PMRDisrupcoes(SelectedDate, SelectedDate);
        }

        public void OnPost()
        {

            SelectedDate = DateTime.Parse(Request.Form["datepicker"].ToString());

            TotalVoosDia = VoosDia(SelectedDate, SelectedDate);
            TotalVoosComAssistencia = VoosComAssistencia(SelectedDate, SelectedDate);

            TotalDisrupcoes = Disrupcoes(SelectedDate, SelectedDate);
            TotalAssistenciasDisrupcoes = AssistenciasDisrupcoes(SelectedDate, SelectedDate);
            TotalPMRDisrupcoes = PMRDisrupcoes(SelectedDate, SelectedDate);
        }

        public int VoosDia(DateTime DataInicio, DateTime DataFim)
        {
            DataInicio = SelectedDate;
            DataFim = SelectedDate;

            int i = db.DadosAeroportos.Where(
                d => d.ScheduleTimeUTC.Value.Day >= DataInicio.Day && d.ScheduleTimeUTC.Value.Day <= DataFim.Day
                ).Select(v => v.Voo).Distinct().Count();

            return i;
        }

        public int VoosComAssistencia(DateTime DataInicio, DateTime DataFim)
        {
            DataInicio = SelectedDate;
            DataFim = SelectedDate;

            int i = db.HistoricoAssistencias.Where(
            d => d.Data.Day >= DataInicio.Day && d.Data.Day <= DataFim.Day
            ).Select(v => v.Voo).Distinct().Count();

            return i;
        }

        public int Disrupcoes(DateTime DataInicio, DateTime DataFim)
        {
            DataInicio = SelectedDate;
            DataFim = SelectedDate;

            int i = db.DadosAeroportos.Where(
                d => (d.ActualTimeUTC <= d.ScheduleTimeUTC.Value.AddMinutes(-30) || d.ActualTimeUTC >= d.ScheduleTimeUTC.Value.AddMinutes(30))
                && d.ScheduleTimeUTC.Value.Day >= DataInicio.Day && d.ScheduleTimeUTC.Value.Day <= DataFim.Day
                ).Count();

            return i;
        }

        public int AssistenciasDisrupcoes(DateTime DataInicio, DateTime DataFim)
        {
            DataInicio = SelectedDate;
            DataFim = SelectedDate;

            int i = db.DadosAeroportos.Where(
                d => (d.ActualTimeUTC <= d.ScheduleTimeUTC.Value.AddMinutes(-30) || d.ActualTimeUTC >= d.ScheduleTimeUTC.Value.AddMinutes(30))
                && d.ScheduleTimeUTC.Value.Day >= DataInicio.Day && d.ScheduleTimeUTC.Value.Day <= DataFim.Day
                && db.HistoricoAssistencias.Where(
                    x => x.Data.Day >= DataInicio.Day && x.Data.Day <= DataFim.Day
                    ).Select(v=>v.Voo).Distinct().Contains(d.Voo)
                ).Count();

            return i;
        }

        public int PMRDisrupcoes(DateTime DataInicio, DateTime DataFim)
        {
            DataInicio = SelectedDate;
            DataFim = SelectedDate;

            var disrupcoes = db.DadosAeroportos.Where(
                d => (d.ActualTimeUTC <= d.ScheduleTimeUTC.Value.AddMinutes(-30) || d.ActualTimeUTC >= d.ScheduleTimeUTC.Value.AddMinutes(30))
                && d.ScheduleTimeUTC.Value.Day >= DataInicio.Day && d.ScheduleTimeUTC.Value.Day <= DataFim.Day
                ).ToList();

            int i = db.HistoricoAssistencias.Where(
            d => d.Data.Day >= DataInicio.Day && d.Data.Day <= DataFim.Day
            && disrupcoes.Select(v => v.Voo).Distinct().Contains(d.Voo)
            ).Count();

            return i;
        }

    }
}