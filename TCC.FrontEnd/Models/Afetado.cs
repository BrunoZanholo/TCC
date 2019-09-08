using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class Afetado
    {
        [DisplayName("Identificador")]
        public int AfetadoId { get; set; }
        public int AreaId { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
    }
}
