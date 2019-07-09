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
    [Breadcrumb("Upload StaffPageData")]
    public class UploadDadosAeroporto : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly string folderName = "Temp";
        private static readonly string[] supportedTypes = new[] { "xls", "xlsx" };
        private IHostingEnvironment env;

        public UploadDadosAeroporto(IHostingEnvironment environment, ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            env = environment;
            db = context;
        }

        public void OnGet()
        {

        }

        public IList<DadosAeroporto> DadosAeroportos { get; set; }
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
                                && !((string)excelTable.Rows[0].ItemArray[0]).Contains("Mov Type")
                                && !((string)excelTable.Rows[0].ItemArray[1]).Contains("Registration")
                                && !((string)excelTable.Rows[0].ItemArray[3]).Contains("Flight Nr")
                                && !((string)excelTable.Rows[0].ItemArray[9]).Contains("Estimated Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[10]).Contains("Schedule Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[11]).Contains("Actual Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[13]).Contains("Block Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[14]).Contains("Begin Boarding Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[15]).Contains("End Boarding Date Time")
                                && !((string)excelTable.Rows[0].ItemArray[25]).Contains("Estimated Date Time UTC")
                                && !((string)excelTable.Rows[0].ItemArray[26]).Contains("Schedule Date Time UTC")
                                && !((string)excelTable.Rows[0].ItemArray[27]).Contains("Actual Date Time UTC")
                                && !((string)excelTable.Rows[0].ItemArray[28]).Contains("Block Date Time UTC")
                                && !((string)excelTable.Rows[0].ItemArray[29]).Contains("Begin Boarding Date Time UTC")
                                && !((string)excelTable.Rows[0].ItemArray[30]).Contains("End Boarding Date Time UTC")
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
                string mov = (string)excelTable.Rows[i].ItemArray[0];
                string reg = (string)excelTable.Rows[i].ItemArray[1];
                string voo = (string)excelTable.Rows[i].ItemArray[3];

                DateTime? estimatedTime = IsItDateNull((string)excelTable.Rows[i].ItemArray[9]);
                DateTime? scheduleTime = IsItDateNull((string)excelTable.Rows[i].ItemArray[10]);
                DateTime? actualTime = IsItDateNull((string)excelTable.Rows[i].ItemArray[11]);
                DateTime? blockTime = IsItDateNull((string)excelTable.Rows[i].ItemArray[13]);
                DateTime? beginBRD = IsItDateNull((string)excelTable.Rows[i].ItemArray[14]);
                DateTime? endBRD = IsItDateNull((string)excelTable.Rows[i].ItemArray[15]);

                DateTime? estimatedTimeUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[25]);
                DateTime? scheduleTimeUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[26]);
                DateTime? actualTimeUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[27]);
                DateTime? blockTimeUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[28]);
                DateTime? beginBRDUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[29]);
                DateTime? endBRDUTC = IsItDateNull((string)excelTable.Rows[i].ItemArray[30]);

                DadosAeroporto currentExcel = new DadosAeroporto
                {
                    Mov = mov,
                    Reg = reg,
                    Voo = voo,

                    EstimatedTime = estimatedTime,
                    ScheduleTime = scheduleTime,
                    ActualTime = actualTime,
                    BlockTime = blockTime,
                    BeginBRD = beginBRD,
                    EndBRD = endBRD,

                    EstimatedTimeUTC = estimatedTimeUTC,
                    ScheduleTimeUTC = scheduleTimeUTC,
                    ActualTimeUTC = actualTimeUTC,
                    BlockTimeUTC = blockTimeUTC,
                    BeginBRDUTC = beginBRDUTC,
                    EndBRDUTC = endBRDUTC
                };

                //db.DadosAeroportos.Add(currentExcel);
                string regv = currentExcel.Reg;
                string movv = currentExcel.Mov;
                DateTime? scheduleTimeUTCv = (DateTime)currentExcel.ScheduleTimeUTC;
                if (!db.DadosAeroportos.Any(e => e.Reg == regv && e.Mov == movv && e.ScheduleTimeUTC == scheduleTimeUTCv))
                {
                    db.DadosAeroportos.Add(currentExcel);
                }

            }

            db.SaveChanges();

        }

        public DateTime? IsItDateNull(string dateFromExcel) {

            if (dateFromExcel == "")
            {
                return null;
            }
            else
            {
                DateTime tempDate = DateTime.Parse(dateFromExcel);
                return tempDate;
            }
            
        }

    }
}