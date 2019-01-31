using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyWayRazor.Data;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.Upload
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly string folderName = "Temp";
        private string Mensagem { get; set; }
        private static readonly string[] supportedTypes = new[] { "xls", "xlsx" };
        private IHostingEnvironment _environment;
        private readonly ILogger _logger;

        public IndexModel(IHostingEnvironment environment, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _environment = environment;
            _logger = logger;
            db = context;
        }

        public void OnGet()
        {
            DelDir(folderName);
            TruncateTable();
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            Mensagem = "";
            if (Upload != null && Upload.Length > 0)
            {
                var myFile = Path.Combine(_environment.ContentRootPath, folderName, Upload.FileName);
                var fileExt = Path.GetExtension(Upload.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    Mensagem = "Tipo de ficheiro não permitido, apenas aceita ficheiros Excel";
                }
                else
                {
                    if (myFile.Length > 0)
                    {
                        using (var fileStream = new FileStream(myFile, FileMode.Create))
                        {
                            await Upload.CopyToAsync(fileStream);
                            fileStream.Close();

                            var stream = System.IO.File.Open(myFile, FileMode.Open, FileAccess.Read);

                            if (fileExt == ".xls")
                            {
                                using (var excelReader = ExcelReaderFactory.CreateBinaryReader(stream))
                                {
                                    AddExcelToDB(excelReader);
                                }
                            }
                            else
                            {
                                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                                {
                                    AddExcelToDB(excelReader);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Mensagem = "Necessita de selecionar um ficheiro";
            }

            if (Mensagem.Length > 0)
                ModelState.AddModelError("erro", Mensagem);

            return RedirectToPage("/Analise/Index");

        }

        private void AddExcelToDB(IExcelDataReader excelReader)
        {
            var excelTable = excelReader.AsDataSet().Tables[0];

            for (var i = 1; i < excelTable.Rows.Count; i++)
            {
                if (!((string)excelTable.Rows[0].ItemArray[0]).Contains("Aeroporto") | !((string)excelTable.Rows[0].ItemArray[1]).Contains("Msg"))
                {
                    ModelState.AddModelError("erro",
                        "Por favor envie o ficheiro correto o cabeçalho não corresponde");
                    break;
                }

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

                this.db.AssistenciasPRMS.Add(currentExcel);
            }

            this.db.SaveChanges();
        }

        private void DelDir(string fn)
        {
            try
            {
                string contentRootPath = _environment.ContentRootPath;
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