using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KairosTest.Models
{
    public class T_BARANG 
    {
        [Key] public int id { get; set; }
        public string? KodeBarang { get; set; }
        public string? NamaBarang { get; set; }
        public int? JumlahBarag { get; set; }
        
    }
}
