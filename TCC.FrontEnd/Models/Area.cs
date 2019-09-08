using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Area
    {
        [DisplayName("Identificador")]
        public int AreaId { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Afetados")]
        public List<Afetado> Afetados { get; set; }
        [DisplayName("Sensores")]
        public List<Sensor> Sensores { get; set; }

        public Area()
        {
            this.Afetados = new List<Afetado>();
            this.Sensores = new List<Sensor>();
        }
    }
}