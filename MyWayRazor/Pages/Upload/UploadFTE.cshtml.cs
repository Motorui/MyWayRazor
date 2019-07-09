using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWayRazor.Data;
using MyWayRazor.Extensions.Alerts;
using MyWayRazor.Helpers;
using MyWayRazor.Models.Analise;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Upload
{
    [Breadcrumb("Upload")]
    public class UploadFTE : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly string folderName = "Temp";
        private static readonly string[] supportedTypes = new[] { "xls", "xlsx" };
        private IHostingEnvironment env;

        public UploadFTE(IHostingEnvironment environment, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            env = environment;
            db = context;
        }

        public void OnGet()
        {

        }

        public IList<Escala> Escalas { get; set; }
        [TempData]
        public string FormResult { get; set; }
        [BindProperty, Required(ErrorMessage = "Por favor selecione um ficheiro!"), Attachment]
        public IFormFile Upload { get; set; }
        public DateTime DataMes { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Upload != null && Upload.Length > 0)
            {
                DataMes = DateTime.Parse(Request.Form["DataMes"]);

                var myFile = Path.Combine(env.ContentRootPath, folderName, Upload.FileName);
                var fileExt = Path.GetExtension(Upload.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError(string.Empty,
                        "Tipo de ficheiro não permitido, apenas aceita ficheiros Excel");
                }
                else
                {
                    if (myFile.Length > 0)
                    {
                        using (var fileStream = new FileStream(myFile, FileMode.Create))
                        {
                            await Upload.CopyToAsync(fileStream);
                            fileStream.Close();
                        }

                        var stream = System.IO.File.Open(myFile, FileMode.Open, FileAccess.Read);

                        using (var excelStream = ExcelReaderFactory.CreateReader(stream))
                        {
                            var excelTable = excelStream.AsDataSet().Tables[0];


                                if (Request.Form["DataMes"] == "")
                                {
                                    ModelState.AddModelError("Error",
                                                    "Por favor selecione um mes");

                                    return Page();
                                }
                                else
                                {
                                    int daysInSelectedMonth = DateTime.DaysInMonth(DataMes.Year, DataMes.Month);
                                    int daysInExcel = (excelTable.Columns.Count - 3);
                                    if (daysInExcel > daysInSelectedMonth)
                                    {
                                        ModelState.AddModelError("Error",
                                        "Por favor verifique se selecionou o ficheiro e o mes correcto!" + Environment.NewLine +
                                        "O ficheiro é refente a " + daysInExcel + " dias " + Environment.NewLine +
                                        "e o mes que selecionou tem " + daysInSelectedMonth + " dias");
                                        return Page();
                                    }
                                }

                                AddExcelToDB(excelStream, DataMes);

                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty,
                    "Necessita de selecionar um ficheiro");
            }

            return RedirectToPage("Index").WithSuccess("Well done!", "Ficheiro importado com sucesso!");
            //return Page();
        }

        private void AddExcelToDB(IExcelDataReader excelReader, DateTime Mes)
        {
            DataTable excelTable = excelReader.AsDataSet().Tables[0];

            for (int i = 1; i < excelTable.Rows.Count; i++)
            {
                DateTime mes = Mes;
                DateTime hEntrada;
                DateTime hSaidaTemp;
                DateTime hSaida;

                string colaborador = (string)excelTable.Rows[i].ItemArray[0].ToString();

                string nome = Regex.Match(colaborador, @"[a-zA-Z\u00C0-\u024F\u1E00-\u1EFF\' ']*").Value.Trim();
                string numero = Regex.Match(colaborador, @"[\d]+").Value.Trim();

                string equipa = (string)excelTable.Rows[i].ItemArray[1].ToString();
                string funcao = (string)excelTable.Rows[i].ItemArray[2].ToString();

                for (int c = 3; c < excelTable.Columns.Count; c++)
                {
                    int ano = mes.Year;
                    int mesactual = mes.Month;
                    DateTime dia = new DateTime(ano, mesactual, (c - 2), 0, 0, 0);

                    string horario = (string)excelTable.Rows[i].ItemArray[c];
                    horario.Trim();
                    bool isLetter = !String.IsNullOrEmpty(horario) && Char.IsLetter(horario[0]);
                    bool isEmpty = String.IsNullOrEmpty(horario);

                    if (isLetter || isEmpty)
                    {
                        hEntrada = new DateTime(ano, mesactual, (c - 2), 0, 0, 0);
                        hSaidaTemp = new DateTime(ano, mesactual, (c - 2), 0, 0, 0);

                    }
                    else
                    {
                        string replace = ":";
                        string result = Regex.Replace(horario, @"\s+", replace);
                        string[] horas = result.Split(":");

                        int he = int.Parse(horas[0]);
                        int me = int.Parse(horas[1]);
                        int hs = int.Parse(horas[2]);
                        int ms = int.Parse(horas[3]);

                        hEntrada = new DateTime(ano, mesactual, (c - 2), he, me, 0);
                        hSaidaTemp = new DateTime(ano, mesactual, (c - 2), hs, ms, 0);

                    }

                    //int dataCompare = DateTime.Compare(hEntrada, hSaida);
                    //if (dataCompare < 0)
                    //{
                    //    hSaida.AddDays(1);
                    //}

                    //System.Diagnostics.Debug.WriteLine("Nome: " +nome+ " Numero; " +numero+ 
                    //    " Equipa: " +equipa+ " Função: " +funcao+ " DIA: " +dia+ " Horário: " +horario+
                    //    " Entrada: "+hEntrada+ " Saída: "+hSaida);

                    if (hEntrada.Hour > hSaidaTemp.Hour | (hEntrada.Hour > 0 && hSaidaTemp.Hour == 0))
                    {
                        hSaida = hSaidaTemp.AddDays(1);
                    }
                    else
                    {
                        hSaida = hSaidaTemp;
                    }

                    Escala currentExcel = new Escala
                    {
                        Nome = nome,
                        Numero = int.Parse(numero),
                        Equipa = equipa,
                        Funcao = funcao,
                        Dia = dia,
                        Horario = horario,
                        HoraEntrada = hEntrada,
                        HoraSaida = hSaida
                    };

                    int current = db.Escalas.Where(d => d.Dia.Date.Day == dia.Date.Day).Count();
                    if (current > 0)
                    {
                        db.Escalas.RemoveRange(db.Escalas.Where(d => d.Dia.Month == DataMes.Month));
                        db.Escalas.Add(currentExcel);
                    }
                    else
                    {
                        db.Escalas.Add(currentExcel);
                    }

                }

            }

            db.SaveChanges();

        }

    }
}