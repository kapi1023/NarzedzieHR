using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Models
{
    public class Pracownik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Imie { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwisko { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataZatrudnienia { get; set; }

        public int StanowiskoId { get; set; }

        [ForeignKey("StanowiskoId")]
        public Stanowisko Stanowisko { get; set; }
    }
}
