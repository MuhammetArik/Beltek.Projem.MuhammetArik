using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beltek.Projem.MuhammetArik.Models
{
    [Table("tblDoktorlar")]
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ICollection<RandevuAl> Randevular { get; set; }
    }
}