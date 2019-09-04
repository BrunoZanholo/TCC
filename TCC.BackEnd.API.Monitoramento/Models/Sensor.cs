using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.BackEnd.API.Monitoramento.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string Rotulo { get; set; }
        public string Nome { get; set; }
    }
}
