using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Incidente
    {
        public int IncidenteId { get; set; }
        public int AreaId { get; set; }
        public DateTime Data { get; set; }
        public int PlanoAcaoId { get; set; }
        public int Classificacao { get; set; }
    }
}
