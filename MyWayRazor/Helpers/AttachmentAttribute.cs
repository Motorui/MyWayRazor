using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MyWayRazor.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AttachmentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
          ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            // The file is required.
            if (file == null)
            {
                return new ValidationResult("Por favor selecione um ficheiro!");
            }

            // The meximum allowed file size is 10MB.
            if (file.Length > 10 * 1024 * 1024)
            {
                return new ValidationResult("Este ficheiro é demasiado grande!");
            }

            // Only PDF can be uploaded.
            string ext = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(ext) ||
               !ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) &&
               !ext.Equals(".xls", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Tipo de ficheiro não permitido, apenas aceita ficheiros Excel!");
            }

            // Everything OK.
            return ValidationResult.Success;
        }
    }
}
