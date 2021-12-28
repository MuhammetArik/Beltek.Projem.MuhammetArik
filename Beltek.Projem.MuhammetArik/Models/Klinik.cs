using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beltek.Projem.MuhammetArik.Models
{
    [Table("tblKlinikler")]
    public class Klinik
    {
        public int KlinikId { get; set; }
        public string Adi { get; set; }
        public ICollection<RandevuAl> Randevular { get; set; }
    }
}