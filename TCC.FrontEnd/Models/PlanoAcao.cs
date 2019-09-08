using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TCC.FrontEnd.Models
{
    public class PlanoAcao
    {
        [DisplayName("Identificador")]
        public int PlanoAcaoId { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Tipo")]
        public string Tipo { get; set; }
        [DisplayName("Mensagem")]
        public string Mensagem { get; set; }
        [DisplayName("Classificação do incidente")]
        public int Classificacao { get; set; }
    }
}
