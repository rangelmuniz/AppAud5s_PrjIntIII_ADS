using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    internal class RepositoryQuestionario
    {
        private BancoContext Banco { get; set; }

        public RepositoryQuestionario()
        {
            Banco = new BancoContext();
        }

        public async Task<Questionario> ConsultarAsync(int Id)
        {
            return await Banco.Questionario.FindAsync(Id);
        }


        public async Task<bool> CadastrarAsync(Questionario questionario)
        {
            Banco.Questionario.Add(questionario);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(Questionario questionario)
        {
            Banco.Questionario.Update(questionario);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
            Questionario questionario = await ConsultarAsync(Id);
            Banco.Questionario.Remove(questionario);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<Questionario>> PesquisarAsync()
        {
            return await Task.FromResult(Banco.Questionario.ToList());
        }

        public async Task<List<Questionario>> PesquisarToModeloPerguntaAsync(int aIdModeloPergunta)
        {
            return await Task.FromResult(Banco.Questionario.Where(x => x.Id_Modelo_Pergunta == aIdModeloPergunta).ToList());
        }


        //public async Task<int> ConsultarMaxNumeroPerguntaAsync(int aIdModeloPergunta, int aIdSenso)
        //{

        //    return await Task.FromResult(Banco.Questionario.Where(x => x.Id_Modelo_Pergunta == aIdModeloPergunta && x.Id_Senso == aIdSenso).Max(x => x.Numero_Pergunta));


        //}


    }
}
