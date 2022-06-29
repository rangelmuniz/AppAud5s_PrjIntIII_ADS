using System;
using System.Collections.Generic;
using System.Text;

namespace AppAud5s.Model
{
    public class Questionario
    {
        public int Id { get; set; }

        public int Id_Modelo_Pergunta { get; set; }
        
        public string Nome_Auditor { get; set; }

        public string Setor { get; set; }

        public DateTime Data_Auditoria { get; set; }

       


    }
}
