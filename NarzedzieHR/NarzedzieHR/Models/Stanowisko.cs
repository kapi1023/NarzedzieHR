﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Models
{
    public class Stanowisko
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }

        [StringLength(255)]
        public string Opis { get; set; }

        public int DzialId { get; set; }

        [ForeignKey("DzialId")]
        public Dzial Dzial { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal StawkaWynagrodzenia { get; set; }
    }
}