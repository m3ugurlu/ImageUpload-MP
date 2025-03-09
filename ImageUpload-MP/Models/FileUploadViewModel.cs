using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Ticareon.Models
{
    public class FileUploadViewModel
    {
        [Required(ErrorMessage = "Lütfen bir dosya seçin.")]
        public IFormFile File { get; set; }
        public string FilePath { get; set; }
    }
}
