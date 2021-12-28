using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Beltek.Projem.MuhammetArik.Models;

namespace Beltek.Projem.MuhammetArik.Models
{
    [Table("tblRandevular")]
    public class RandevuAl
    {
        public int RandevuId { get; set; }
        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }
        public int KlinikId { get; set; }
        public Klinik Klinik { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        public DateTime RandevuZamani { get; set; }
    }
}