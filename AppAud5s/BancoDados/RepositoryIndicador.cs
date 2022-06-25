using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    internal class RepositoryIndicador
    {
        private BancoContext Banco { get; set; }

        public RepositoryIndicador()
        {
            Banco = new BancoContext();
        }

        public async Task<Indicador> ConsultarAsync(int Id)
        {
            return await Banco.Indicador.FindAsync(Id);
        }

        public async Task<Indicador> ConsultarNotaPeloModeloAsync(int Id)
        {
            return await Banco.Indicador.FindAsync(Id);
        }

        public async Task<bool> CadastrarAsync(Indicador indicador)
        {
            Banco.Indicador.Add(indicador);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(Indicador indicador)
        {
            Banco.Indicador.Update(indicador);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
            Indicador indicador = await ConsultarAsync(Id);
            Banco.Indicador.Remove(indicador);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<Indicador>> PesquisarAsync(int IdModelo)
        {
           // return await Task.FromResult(Banco.Indicador.ToList());
          return await Task.FromResult(Banco.Indicador.Where(x=> x.Id_Modelo == IdModelo).ToList());
           // List<Indicador> indicador = await Task.FromResult(Banco.Indicador.Where(x=> x.Id_Modelo == CodModelo).ToList());           


        }

    }
}
