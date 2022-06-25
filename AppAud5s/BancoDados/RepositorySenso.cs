using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    internal class RepositorySenso
    {
        private BancoContext Banco { get; set; }

        public RepositorySenso()
        {
            Banco = new BancoContext();
        }

        public async Task<bool> CadastrarAsync(Senso senso)
        {
            Banco.Senso.Add(senso);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<Senso>> PesquisarAsync(int Id)
        {
            return await Task.FromResult(Banco.Senso.Where(x => x.Id == Id).ToList());
        }

        public async Task<List<Senso>> PesquisarTotalAsync()
        {
            return await Task.FromResult(Banco.Senso.ToList());
        }
    }

}
