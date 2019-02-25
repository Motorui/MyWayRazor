using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWayRazor.Data;
using MyWayRazor.Helpers;
using MyWayRazor.Models.Analise;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Upload
{
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
                TruncateTable();

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

            //return RedirectToPage("/Upload/Index");
            return RedirectToPage("/Analise/Index");

        }

        private void AddExcelToDB(IExcelDataReader excelReader)
        {
            var excelTable = excelReader.AsDataSet().Tables[0];

            for (var i = 1; i < excelTable.Rows.Count; i++)
            {
                var aeroporto = (string)excelTable.Rows[i].ItemArray[0];
                var msg = (string)excelTable.Rows[i].ItemArray[1];
                var notif = (string)excelTable.Rows[i].ItemArray[2];
                var data = (DateTime)excelTable.Rows[i].ItemArray[3];
                var voo = (string)excelTable.Rows[i].ItemArray[4];
                var mov = (string)excelTable.Rows[i].ItemArray[5];
                var origDest = (string)excelTable.Rows[i].ItemArray[6];
                var pax = (string)excelTable.Rows[i].ItemArray[7];
                var ssr = (string)excelTable.Rows[i].ItemArray[8];
                var ac = (string)excelTable.Rows[i].ItemArray[9];
                var stand = (string)excelTable.Rows[i].ItemArray[10];
                var exit = (string)excelTable.Rows[i].ItemArray[11];
                var ckin = (string)excelTable.Rows[i].ItemArray[12];
                var gate = (string)excelTable.Rows[i].ItemArray[13];
                var transferencia = (string)excelTable.Rows[i].ItemArray[14];

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
                    Transferencia = transferencia
                };
                var current = db.AssistenciasPRMS.Find(currentExcel.Data, currentExcel.Voo, currentExcel.Pax);
                if (current == null)
                {
                    db.AssistenciasPRMS.Add(currentExcel);
                }
                else
                {
                    db.Entry(current).CurrentValues.SetValues(currentExcel);
                }

            }

            db.SaveChanges();
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

    }
}