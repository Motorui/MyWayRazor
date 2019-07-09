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
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Upload
{
    [Breadcrumb("Upload Histórico")]
    public class UploadHistorico : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly string folderName = "Temp";
        private static readonly string[] supportedTypes = new[] { "xls", "xlsx" };
        private IHostingEnvironment env;

        public UploadHistorico(IHostingEnvironment environment, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            env = environment;
            db = context;
        }

        public void OnGet()
        {

        }

        public IList<HistoricoAssistencia> HistoricoAssistencias { get; set; }
        [TempData]
        public string FormResult { get; set; }
        [BindProperty, Required(ErrorMessage = "Por favor selecione um ficheiro!"), Attachment]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Upload != null && Upload.Length > 0)
            {
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
                            if (
                                excelTable.Rows[0].ItemArray[0].ToString() != null
                                && !((string)excelTable.Rows[0].ItemArray[0]).Contains("Tipo Msg")
                                && !((string)excelTable.Rows[0].ItemArray[1]).Contains("Aeroporto")
                                && !((string)excelTable.Rows[0].ItemArray[2]).Contains("Notif")
                                && !((string)excelTable.Rows[0].ItemArray[3]).Contains("Data Voo")
                                && !((string)excelTable.Rows[0].ItemArray[5]).Contains("Data Contacto")
                                && !((string)excelTable.Rows[0].ItemArray[7]).Contains("Data Inicio Assistencia")
                                && !((string)excelTable.Rows[0].ItemArray[9]).Contains("Data Fim Assistencia")
                                && !((string)excelTable.Rows[0].ItemArray[11]).Contains("Voo")
                                && !((string)excelTable.Rows[0].ItemArray[12]).Contains("Mov")
                                && !((string)excelTable.Rows[0].ItemArray[13]).Contains("Orig Dest")
                                && !((string)excelTable.Rows[0].ItemArray[14]).Contains("Pax")
                                && !((string)excelTable.Rows[0].ItemArray[15]).Contains("SSR")
                                && !((string)excelTable.Rows[0].ItemArray[16]).Contains("AC")
                                && !((string)excelTable.Rows[0].ItemArray[17]).Contains("Stand")
                                && !((string)excelTable.Rows[0].ItemArray[18]).Contains("Exit")
                                )
                            {
                                ModelState.AddModelError("Error",
                                    "Por favor envie o ficheiro correto o cabeçalho não corresponde");
                                return Page();
                            }
                            else
                            {
                                AddExcelToDB(excelStream);
                            }

                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty,
                    "Necessita de selecionar um ficheiro");
            }

            return RedirectToPage("/Analise/Disrupcoes").WithSuccess("Well done!", "Ficheiro importado com sucesso!");
            //return Page();
        }

        private void AddExcelToDB(IExcelDataReader excelReader)
        {
            DataTable excelTable = excelReader.AsDataSet().Tables[0];

            for (int i = 1; i < excelTable.Rows.Count; i++)
            {
                string msg = (string)excelTable.Rows[i].ItemArray[0];
                string aeroporto = (string)excelTable.Rows[i].ItemArray[1];
                string notif = (string)excelTable.Rows[i].ItemArray[2];
                DateTime data = Convert.ToDateTime(excelTable.Rows[i].ItemArray[3] + " " + excelTable.Rows[i].ItemArray[4]);
                DateTime? dataContacto = IsItDateNull((string)excelTable.Rows[i].ItemArray[5], (string)excelTable.Rows[i].ItemArray[6]);
                DateTime? dataInicio = IsItDateNull((string)excelTable.Rows[i].ItemArray[7], (string)excelTable.Rows[i].ItemArray[8]);
                DateTime? dataFim = IsItDateNull((string)excelTable.Rows[i].ItemArray[9], (string)excelTable.Rows[i].ItemArray[10]);
                string voo = (string)excelTable.Rows[i].ItemArray[11];
                string mov = (string)excelTable.Rows[i].ItemArray[12];
                string origDest = (string)excelTable.Rows[i].ItemArray[13];
                string pax = (string)excelTable.Rows[i].ItemArray[14];
                string ssr = (string)excelTable.Rows[i].ItemArray[15];
                string ac = (string)excelTable.Rows[i].ItemArray[16];
                string stand = (string)excelTable.Rows[i].ItemArray[17];
                string exit = (string)excelTable.Rows[i].ItemArray[18];
                string ckIn = (string)excelTable.Rows[i].ItemArray[19];
                string gate = (string)excelTable.Rows[i].ItemArray[20];
                string transferencia = (string)excelTable.Rows[i].ItemArray[21];

                HistoricoAssistencia currentExcel = new HistoricoAssistencia
                {
                    Msg = msg,
                    Aeroporto = aeroporto,
                    Notif = notif,
                    Data = data,
                    DataContacto = dataContacto,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    Voo = voo,
                    Mov = mov,
                    OrigDest = origDest,
                    Pax = pax,
                    SSR = ssr,
                    AC = ac,
                    Stand = stand,
                    Exit = exit,
                    CkIn = ckIn,
                    Gate = gate,
                    Transferencia = transferencia
                };

                DateTime? dataV = (DateTime)currentExcel.Data;
                string vooV = currentExcel.Voo;
                string paxV = currentExcel.Pax;
                if (!db.HistoricoAssistencias.Any(e => e.Data == dataV && e.Voo == vooV && e.Pax == paxV))
                {
                    db.HistoricoAssistencias.Add(currentExcel);
                }

            }

            db.SaveChanges();

        }

        public DateTime? IsItDateNull(string dateFromExcel, string timeFromExcel) {

            if (dateFromExcel == "" || timeFromExcel == "")
            {
                return null;
            }
            else
            {
                DateTime tempDate = Convert.ToDateTime(dateFromExcel + " " + timeFromExcel);
                //DateTime tempDate = DateTime.Parse(tempDateUnparsed);
                return tempDate;
            }
            
        }

    }
}