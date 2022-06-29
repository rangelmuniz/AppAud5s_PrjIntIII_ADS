using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    internal class RepositoryQuestionarioSenso
    {
        private BancoContext Banco { get; set; }

        public RepositoryQuestionarioSenso()
        {
            Banco = new BancoContext();
        }

        public async Task<QuestionarioSenso> ConsultarAsync(int Id)
        {
            return await Banco.QuestionarioSenso.FindAsync(Id);
        }


        public async Task<bool> CadastrarAsync(QuestionarioSenso questionarioSenso)
        {
            Banco.QuestionarioSenso.Add(questionarioSenso);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(QuestionarioSenso questionarioSenso)
        {
            Banco.QuestionarioSenso.Update(questionarioSenso);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
            QuestionarioSenso questionarioSenso = await ConsultarAsync(Id);
            Banco.QuestionarioSenso.Remove(questionarioSenso);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<QuestionarioSenso>> PesquisarAsync()
        {
            return await Task.FromResult(Banco.QuestionarioSenso.ToList());
        }

        public async Task<List<QuestionarioSenso>> PesquisarToModeloPerguntaAsync(int aIdQuestionario)
        {
            return await Task.FromResult(Banco.QuestionarioSenso.Where(x => x.Id_Questionario == aIdQuestionario).ToList());
        }


        //public async Task<int> ConsultarMaxNumeroPerguntaAsync(int aIdModeloPergunta, int aIdSenso)
        //{

        //    return await Task.FromResult(Banco.Questionario.Where(x => x.Id_Modelo_Pergunta == aIdModeloPergunta && x.Id_Senso == aIdSenso).Max(x => x.Numero_Pergunta));


        //}

    }
}
