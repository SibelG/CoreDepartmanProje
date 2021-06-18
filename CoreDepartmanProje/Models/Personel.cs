using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartmanProje.Models
{
    public class Personel
    {
        [Key]
        public int ID { get; set; }
        public string  perName { get; set; }
        public string perLastName { get; set; }
        public string city { get; set; }
        public int birimId { get; set; }
        public Birim Birim { get; set; }
    }
}
