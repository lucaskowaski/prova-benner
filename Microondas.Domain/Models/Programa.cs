using System;
using System.Collections.Generic;
using System.Text;

namespace Microondas.Domain.Models
{
    class Programa
    {
        #region Constructor
        public Programa(){}
        public Programa(string nome, string instruções, int tempo, int potencia, string TipoAlimento, string Caractere)
        {
            this.Nome = nome;
            this.Instruções = instruções;
            this.Tempo = tempo;
            this.Potencia = potencia;
            this.TipoAlimento = TipoAlimento;
            this.Caractere = Caractere;
        }
        #endregion
        #region Properties
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Instruções { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string TipoAlimento { get; set; }
        public string Caractere { get; set; }
        #endregion
        #region Methods
        public List<Programa> ObterPadroes()
        {
            List<Programa> padroes = new List<Programa>();
            padroes.Add(new Programa() {
                Id = new Guid().ToString(),
                Nome = "Ovo",
                Instruções = "Nunca cozinhe ovos com casca. Nunca aqueça ovoscozidos",
                Tempo =  20,
                Potencia = 2,
                Caractere = "A",
                TipoAlimento = "Ovo"
            });
            padroes.Add(new Programa()
            {
                Id = new Guid().ToString(),
                Nome = "Bebidas",
                Instruções = "Nunca aqueça bebidas ou outros tipos de alimentos contidos em recipientes totalmente fechados",
                Tempo = 50,
                Potencia = 5,
                Caractere = "su",
                TipoAlimento = "Bebidas"
            });
            padroes.Add(new Programa()
            {
                Id = new Guid().ToString(),
                Nome = "Carne",
                Instruções = "Nunca aqueça alimentos dentro de embalagens térmicas. ",
                Tempo = 100,
                Potencia = 8,
                Caractere = "C",
                TipoAlimento = "Carne"
            });
            padroes.Add(new Programa()
            {
                Id = new Guid().ToString(),
                Nome = "Frango",
                Instruções = "Embalagens herméticas podem explodir por ação do calor. ",
                Tempo = 80,
                Potencia = 5,
                Caractere = "D",
                TipoAlimento = "Frango"
            });
            padroes.Add(new Programa()
            {
                Id = new Guid().ToString(),
                Nome = "Peixe",
                Instruções = "Nunca utilize formas esmaltadas em seu micro-ondas afim de evitar possíveis avarias no produto",
                Tempo = 20,
                Potencia = 4,
                Caractere = "E",
                TipoAlimento = "Peixe"
            });
            return padroes;
        }
        #endregion
    }
}
