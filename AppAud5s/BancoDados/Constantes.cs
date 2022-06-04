using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppAud5s.BancoDados
{
    public static class Constantes
    {
        public const string NomeBanco = "AppAud5s.db3";     

        public static string CaminhoBanco
        {
            get
            {
                var CaminhoBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(CaminhoBase, NomeBanco);
            }
        }
    }
}
