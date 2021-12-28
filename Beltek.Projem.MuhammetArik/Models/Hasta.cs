using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beltek.Projem.MuhammetArik.Models
{
    [Table("tblHastalar")]
    public class Hasta
    {
        public int HastaId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCNo { get; set; }
    }
}