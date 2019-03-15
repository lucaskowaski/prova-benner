using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Microondas.Domain.Models
{
    class Microonda
    {
        #region Constructor
        public Microonda() { }
        public Microonda(String alimento, int tempo, int potencia, string Caractere)
        {
            this.Alimento = alimento;
            this.Tempo = tempo;
            this.Potencia = potencia;
            this.Caractere = Caractere;
        }
        #endregion
        #region Properties
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string Caractere { get; set; }
        public string ServerPath { get; set; }
        public int TempoPercorrido { get; set; }
        public bool ligado { get; set; }
        #endregion
        #region Methods
        public string Ligar(Func<int, string, bool> notification)
        {
            ligado = true;
            int tempoInicio = TempoPercorrido > 0 ? TempoPercorrido : 1;
            string pontos = "";
            string caractere = Caractere == null ? "." : Caractere;
            for (int i = 0; i < Potencia; i++)
            {
                pontos += caractere;
            }
            string path = Path.Combine(ServerPath, Alimento);
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, false))
                {
                    int i = tempoInicio;
                    while (i < Tempo && ligado)
                    {
                        Thread.Sleep(1000);
                        file.Write(caractere);
                        Alimento += pontos;
                        i++;
                    }
                }
            }
            else
            {
                int i = tempoInicio;
                while (i < Tempo && ligado)
                {
                    Thread.Sleep(1000);
                    Alimento += pontos;
                    notification(i, Alimento);
                    i++;
                }
            }
            return Alimento;
        }
        #endregion
    }
}
