using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAud5s.BancoDados
{
    public class Repository
    {
         private BancoContext Banco { get; set; }

        public Repository()
        {
            Banco = new BancoContext();
        }

        public async Task<ModeloNota> ConsultarAsync(int Id)
        {
            return await Banco.ModeloNotas.FindAsync(Id);
        }

        public async Task<bool> CadastrarAsync(ModeloNota Modelo)
        {
            Banco.ModeloNotas.Add(Modelo); 
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(ModeloNota Modelo)
        {
            Banco.ModeloNotas.Update(Modelo);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int Id)
        {
          ModeloNota Modelo = await ConsultarAsync(Id);
            Banco.ModeloNotas.Remove(Modelo);
            int Linhas = await Banco.SaveChangesAsync();
            return (Linhas > 0) ? true : false;
        }  
        
        public async Task<List<ModeloNota>> PesquisarAsync()
        {
            return await Task.FromResult(Banco.ModeloNotas.ToList());
        }
    }

}
