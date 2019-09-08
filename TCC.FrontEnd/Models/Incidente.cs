using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Incidente
    {
        [DisplayName("Identificador")]
        public int IncidenteId { get; set; }
        public int AreaId { get; set; }
        [DisplayName("Area")]
        public Area Area { get; set; }
        [DisplayName("Data")]
        public DateTime Data { get; set; }
        public int PlanoAcaoId { get; set; }
        [DisplayName("Plano de ação")]
        public PlanoAcao PlanoAcao { get; set; }
        [DisplayName("Classificação")]
        public int Classificacao { get; set; }
    }
}
