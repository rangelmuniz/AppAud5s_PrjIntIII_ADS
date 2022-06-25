using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    internal class RepositoryModeloPergunta
    {
        private BancoContext Banco { get; set; }

        public RepositoryModeloPergunta()
        {
            Banco = new BancoContext();
        }

        public async Task<ModeloPergunta> ConsultarAsync(int Id)
        {
            return await Banco.ModeloPergunta.FindAsync(Id);
        }

        public async Task<bool> CadastrarAsync(ModeloPergunta Modelo)
        {
            Banco.ModeloPergunta.Add(Modelo);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(ModeloPergunta Modelo)
        {
            Banco.ModeloPergunta.Update(Modelo);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
            ModeloPergunta Modelo = await ConsultarAsync(Id);
            Banco.ModeloPergunta.Remove(Modelo);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<ModeloPergunta>> PesquisarAsync()
        {
            return await Task.FromResult(Banco.ModeloPergunta.ToList());
        }




    }
}
