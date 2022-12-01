using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace KairosTest.Models
{
    public class crudBarang
    {
        [Key]
        public int? @id { get; set; }
        public string? @NamaBarang { get; set; }
        public string? @KodeBarang { get; set; }
        public int? @JumlahBarag { get; set; }
        public string? @Search { get; set; }
        public int? @ActionType { get; set; }
    }
}
