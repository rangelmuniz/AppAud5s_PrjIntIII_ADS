using System;
using System.Collections.Generic;
using System.Text;

namespace AppAud5s.Model
{
    public class Pergunta
    {
        public int Id { get; set; }
        public int Id_Modelo_Pergunta { get; set; }
        public int Id_Senso { get; set; } 
        public string Nome_Senso { get; set; }
        public int Numero_Pergunta { get; set; }
        public string Desc_Pergunta { get; set; }
        
    }
}
