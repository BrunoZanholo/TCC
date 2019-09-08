using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Sensor
    {
        [DisplayName("Identificador")]
        public int SensorId { get; set; }
        public int AreaId { get; set; }
        [DisplayName("Rótulo")]
        public string Rotulo { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}