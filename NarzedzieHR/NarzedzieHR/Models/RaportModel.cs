using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Models
{
    public class RaportModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int PrzepracowaneGodziny { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal StawkaWynagrodzenia { get; set; }

        public int PracownikId { get; set; }

        [ForeignKey("PracownikId")]
        public PracownikModel Pracownik { get; set; }

        public int StanowiskoId { get; set; }

        [ForeignKey("StanowiskoId")]
        public StanowiskoModel Stanowisko { get; set; }
    }
}
