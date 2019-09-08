using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Afetado
    {
        public int AfetadoId { get; set; }
        public int AreaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
