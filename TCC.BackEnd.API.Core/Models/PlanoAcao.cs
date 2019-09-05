using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.BackEnd.API.Core.Models
{
    public class PlanoAcao
    {
        public int PlanoAcaoId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }  
        public int Classificacao { get; set; }
    }
}
