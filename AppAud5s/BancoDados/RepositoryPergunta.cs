using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAud5s.Model;

namespace AppAud5s.BancoDados
{    
    internal class RepositoryPergunta
    {
         private BancoContext Banco { get; set; }

        public RepositoryPergunta()
        {
            Banco = new BancoContext();
        }

        public async Task<Pergunta> ConsultarAsync(int Id)
        {
            return await Banco.Pergunta.FindAsync(Id);
        }    


        public async Task<bool> CadastrarAsync(Pergunta pergunta)
        {
            Banco.Pergunta.Add(pergunta);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(Pergunta pergunta)
        {
            Banco.Pergunta.Update(pergunta);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
            Pergunta pergunta = await ConsultarAsync(Id);
            Banco.Pergunta.Remove(pergunta);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<List<Pergunta>> PesquisarAsync()
        {
            return await Task.FromResult(Banco.Pergunta.ToList());
        }

        public async Task<List<Pergunta>> PesquisarToModeloSensoAsync(int aIdModeloPergunta, int aIdSenso)
        {
            return await Task.FromResult(Banco.Pergunta.Where(x=> x.Id_Modelo_Pergunta == aIdModeloPergunta && x.Id_Senso == aIdSenso).ToList());
        }


        public async Task<int> ConsultarMaxNumeroPerguntaAsync(int aIdModeloPergunta, int aIdSenso)
        {           
                     
            return await Task.FromResult(Banco.Pergunta.Where(x => x.Id_Modelo_Pergunta == aIdModeloPergunta && x.Id_Senso == aIdSenso).Max(x => x.Numero_Pergunta));
            
            
        }



    }
}
