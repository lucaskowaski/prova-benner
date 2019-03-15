using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microondas.Domain.ViewModels
{
    public class MicroondasViewModel
    {
        [Required]
        [Display(Name = "Alimento")]
        public string Alimento { get; set; }
        [Required]
        [Display(Name = "Tempo")]
        [Range(1, 120)]
        public int Tempo { get; set; }
        [Required]
        [Display(Name = "Potencia")]
        [Range(1, 10)]
        public int Potencia { get; set; }
        public string Caractere  {get; set; }
        public string ServerPath { get; set; }
        public int TempoPercorrido { get; set; }
    }
}
