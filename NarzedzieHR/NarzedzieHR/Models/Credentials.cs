using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Models
{
    public class Credentials
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Haslo { get; set; }

        public int PracownikId { get; set; }

        [ForeignKey("PracownikId")]
        public Pracownik Pracownik { get; set; }
    }
}
