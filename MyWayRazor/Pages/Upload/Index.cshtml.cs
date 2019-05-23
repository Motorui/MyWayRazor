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
using MyWayRazor.Models.Tabelas;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Upload
{
    [Breadcrumb("Upload")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly string folderName = "Temp";
        private static readonly string[] supportedTypes = new[] { "xls", "xlsx" };
        private IHostingEnvironment env;

        public IndexModel(IHostingEnvironment environment, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            env = environment;
            db = context;
        }

        public void OnGet()
        {
            //DelDir(folderName);
            //TruncateTable();
        }

        public IList<AssistenciasPRM> Assistencias { get; set; }
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
                db.AssistenciasPRMS.RemoveRange(db.AssistenciasPRMS.Where(d => d.Data <= DateTime.UtcNow.AddDays(-1)));

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
                                && !((string)excelTable.Rows[0].ItemArray[0]).Contains("Aeroporto")
                                && !((string)excelTable.Rows[0].ItemArray[1]).Contains("Msg")
                                && !((string)excelTable.Rows[0].ItemArray[2]).Contains("Notif")
                                && !((string)excelTable.Rows[0].ItemArray[3]).Contains("Data")
                                && !((string)excelTable.Rows[0].ItemArray[4]).Contains("Voo")
                                && !((string)excelTable.Rows[0].ItemArray[5]).Contains("Mov")
                                && !((string)excelTable.Rows[0].ItemArray[6]).Contains("Orig Dest")
                                && !((string)excelTable.Rows[0].ItemArray[7]).Contains("Pax")
                                && !((string)excelTable.Rows[0].ItemArray[8]).Contains("SSR")
                                && !((string)excelTable.Rows[0].ItemArray[9]).Contains("AC")
                                && !((string)excelTable.Rows[0].ItemArray[10]).Contains("Stand")
                                && !((string)excelTable.Rows[0].ItemArray[11]).Contains("Exit")
                                && !((string)excelTable.Rows[0].ItemArray[12]).Contains("Ck In")
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

            return RedirectToPage("/Analise/Index").WithSuccess("Well done!", "Ficheiro importado com sucesso!"); ;
            //return Page();
        }

        public IList<Parametro> Parametro { get; set; }
        public IList<Porta> Porta { get; set; }

        private void AddExcelToDB(IExcelDataReader excelReader)
        {
            DataTable excelTable = excelReader.AsDataSet().Tables[0];

            for (int i = 1; i < excelTable.Rows.Count; i++)
            {
                string aeroporto = (string)excelTable.Rows[i].ItemArray[0];
                string msg = (string)excelTable.Rows[i].ItemArray[1];
                string notif = (string)excelTable.Rows[i].ItemArray[2];
                DateTime data = (DateTime)excelTable.Rows[i].ItemArray[3];
                string voo = (string)excelTable.Rows[i].ItemArray[4];
                string mov = (string)excelTable.Rows[i].ItemArray[5];
                string origDest = (string)excelTable.Rows[i].ItemArray[6];
                string pax = (string)excelTable.Rows[i].ItemArray[7];
                string ssr = (string)excelTable.Rows[i].ItemArray[8];
                string ac = (string)excelTable.Rows[i].ItemArray[9];
                string stand = (string)excelTable.Rows[i].ItemArray[10];

                if (string.IsNullOrEmpty(stand))
                {
                    stand = "000";
                }
                
                string exit = (string)excelTable.Rows[i].ItemArray[11];
                string ckin = (string)excelTable.Rows[i].ItemArray[12];
                string gate = (string)excelTable.Rows[i].ItemArray[13];
                string transferencia = (string)excelTable.Rows[i].ItemArray[14];
                DateTime horaEmbarque = data.AddMinutes(-BrdTime(gate));
                DateTime saidaStaging = data.AddMinutes(-StagingTime(gate));
                DateTime estimaApresentacao = data.AddMinutes(-EstimaTime(gate));

                AssistenciasPRM currentExcel = new AssistenciasPRM
                {
                    Aeroporto = aeroporto,
                    Msg = msg,
                    Notif = notif,
                    Data = data,
                    Voo = voo,
                    Mov = mov,
                    OrigDest = origDest,
                    Pax = pax,
                    SSR = ssr,
                    AC = ac,
                    Stand = stand,
                    Exit = exit,
                    CkIn = ckin,
                    Gate = gate,
                    Transferencia = transferencia,
                    HoraEmbarque = horaEmbarque,
                    SaidaStaging = saidaStaging,
                    EstimaApresentacao = estimaApresentacao
                };

                int current = db.AssistenciasPRMS.Where(d => d.Data.Date.Day == data.Date.Day).Count();
                if (current > 0)
                {
                    db.AssistenciasPRMS.RemoveRange(db.AssistenciasPRMS.Where(d => d.Data.Date == data.Date));
                    db.AssistenciasPRMS.Add(currentExcel);
                }
                else
                {
                    db.AssistenciasPRMS.Add(currentExcel);
                }

            }

            db.SaveChanges();

        }

        private int BrdTime(string gate)
        {
            bool gateExist = db.Portas.Any(g => g.PortaNum.Equals(gate));

            if (gateExist)
            {
                Porta queryP = db.Portas.FirstOrDefault(g => g.PortaNum.Equals(gate));

                bool schengen = queryP.Schengen;
                int tempoTotal = (schengen == true) ? 40 : 60 ;
                return tempoTotal;
            }
            else
            {
                return 0;
            }
        }

        private int StagingTime(string gate)
        {
            bool gateExist = db.Portas.Any(g => g.PortaNum.Equals(gate));

            if (gateExist)
            {
                Porta queryP = db.Portas.FirstOrDefault(g => g.PortaNum.Equals(gate));

                int portaTempo = queryP.PortaTempo;

                bool schengen = queryP.Schengen;
                int tempoTotal = (schengen == true) ? 40 + portaTempo : 60 + portaTempo;
                return tempoTotal;
            }
            else
            {
                return 0;
            }            
        }

        private int EstimaTime(string gate)
        {
            bool gateExist = db.Portas.Any(g => g.PortaNum.Equals(gate));

            if (gateExist)
            {
                Porta queryPorta = db.Portas.FirstOrDefault(g => g.PortaNum.Equals(gate));

                bool schengen = queryPorta.Schengen;
                string paramNome = (schengen == true) ? "CPS" : "CPN";

                Parametro queryParam = db.Parametros.FirstOrDefault(p => p.ParamNome.Equals(paramNome));
                int tempoTotal = (int)queryParam.ParamValue;
                return tempoTotal;
            }
            else
            {
                return 0;
            }
        }

        private void DelDir(string fn)
        {
            try
            {
                string contentRootPath = env.ContentRootPath;
                var myPath = Path.Combine(contentRootPath, fn);

                if (!Directory.Exists(myPath))
                {
                    Directory.CreateDirectory(myPath);
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(myPath);
                    foreach (FileInfo file in di.EnumerateFiles())
                    {
                        file.Delete();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TruncateTable()
        {
            try
            {
                db.Database.ExecuteSqlCommand("Delete from AssistenciasPRMS");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DeleteAssistencias(DateTime dia)
        {
            var assistencias = db.AssistenciasPRMS
                .Where(d => d.Data == dia);

                        foreach (var assistencia in assistencias)
                        {
                            db.AssistenciasPRMS.Remove(assistencia);
                        }
                        db.SaveChanges();
        }

    }
}