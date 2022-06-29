using System;
using System.Collections.Generic;
using System.Text;

namespace AppAud5s.Model
{
    public class QuestionarioSenso
    {
        public int Id { get; set; }
        public int Id_Questionario { get; set; }
        public int Id_Senso { get; set; }
        public double Peso { get; set; }
        public string Conforme { get; set; }
        public string Obeservacao { get; set; }

    }
}
