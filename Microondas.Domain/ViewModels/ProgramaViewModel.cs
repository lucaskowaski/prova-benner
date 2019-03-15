using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microondas.Domain.ViewModels
{
    public class ProgramaViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Instruções")]
        public string Instrucoes { get; set; }
        [Required]
        [Display(Name = "Tempo")]
        [Range(1, 120)]
        [RegularExpression("([0-9]+)", ErrorMessage = "O tempo deve ser um número inteiro válido")]
        public int Tempo { get; set; }
        [Required]
        [Display(Name = "Potencia")]
        [Range(1, 10)]
        [RegularExpression("([0-9]+)", ErrorMessage ="A potência deve ser um número inteiro válido")]
        public int Potencia { get; set; }
        [Required]
        [Display(Name = "Tipo de Alimento")]
        public string TipoAlimento { get; set; }
        [Required]
        [Display(Name = "Caractere de Aquecimento")]
        public string Caractere { get; set; }
    }
}
