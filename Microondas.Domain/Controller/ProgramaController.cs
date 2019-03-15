using Microondas.Domain.Models;
using Microondas.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Microondas.Domain.Controller
{
    public class ProgramaController
    {
        public List<ProgramaViewModel> ObterProgramasPadrao()
        {
            List<Programa> programas = new Programa().ObterPadroes();
            return (from p in programas
                    select new ProgramaViewModel()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Instrucoes = p.Instruções,
                        Tempo = p.Tempo,
                        Potencia = p.Potencia,
                        Caractere = p.Caractere,
                        TipoAlimento = p.TipoAlimento
                    }).ToList();
        }
    }
}
