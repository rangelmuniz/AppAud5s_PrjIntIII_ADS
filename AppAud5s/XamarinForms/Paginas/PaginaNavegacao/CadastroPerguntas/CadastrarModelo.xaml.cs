using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAud5s.Model;
using AppAud5s.BancoDados;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarModelo : ContentPage
    {
        public CadastrarModelo()
        {
            InitializeComponent();
        }

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void btnSalvarModelo(object sender, EventArgs e)
        {
            ModeloPergunta modelo = new ModeloPergunta();

            modelo.Nome = Nome.Text;

            if (await ValidacaoAsync(modelo))
            {
                //TODO - Salvar o modelo no banco
                if (await new RepositoryModeloPergunta().CadastrarAsync(modelo))
                {

                    MessagingCenter.Send<CadastroModeloPergunta, ModeloPergunta>(new CadastroModeloPergunta(), "onModeloPerguntaCadastrado", modelo);
                    await Navigation.PopModalAsync();
                }
            }


            //TODO - MessagingCenter retornar a tarefa na tela de listar
        }

        private async Task<bool> ValidacaoAsync(ModeloPergunta modelo)
        {
            return await Task.FromResult(true);
        }
    }
}
