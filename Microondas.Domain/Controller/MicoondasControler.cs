using Microondas.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microondas.Domain.Models;

namespace Microondas.Domain.Controller
{
    public class MicoondasControler
    {
        Microonda microondas = new Microonda();
        public string Ligar(MicroondasViewModel microondasVm, Func<int, string, bool> notification)
        {
            microondas.Alimento = microondasVm.Alimento;
            microondas.Tempo = microondasVm.Tempo;
            microondas.Potencia = microondasVm.Potencia;
            microondas.Caractere = microondasVm.Caractere;
            microondas.ServerPath = microondasVm.ServerPath;
            microondas.TempoPercorrido = microondasVm.TempoPercorrido;
            microondas.Ligar(notification);
            return microondas.Alimento;
        }
        public void Desligar()
        {
            this.microondas.ligado = false;
        }
    }
}
