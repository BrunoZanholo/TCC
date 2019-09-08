using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Atividade
    {
        public int AtividadeId { get; set; }
        public string RotuloSensor { get; set; }
        public string Tipo { get; set; }
        public int Intensidade { get; set; }
    }
}