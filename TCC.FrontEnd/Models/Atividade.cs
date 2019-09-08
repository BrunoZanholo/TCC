using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Atividade
    {
        [DisplayName("Identificador")]
        public int AtividadeId { get; set; }
        public string RotuloSensor { get; set; }
        public Sensor Sensor { get; set; }
        [DisplayName("Tipo")]
        public string Tipo { get; set; }
        [DisplayName("Intensidade")]
        public int Intensidade { get; set; }
        [DisplayName("Data")]
        public DateTime Data { get; set; }
    }
}