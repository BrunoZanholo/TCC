using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.BackEnd.API.Core.Models
{
    public class Atividade
    {
        public int AtividadeId { get; set; }
        public int RotuloSensor { get; set; }
        public string Tipo { get; set; }
        public int Intensidade { get; set; }
    }
}
