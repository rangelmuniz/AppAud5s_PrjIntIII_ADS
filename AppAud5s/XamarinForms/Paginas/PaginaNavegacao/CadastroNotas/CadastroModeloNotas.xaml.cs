using AppAud5s.BancoDados;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;


namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroModeloNotas : ContentPage{ 

        public CadastroModeloNotas()
        {
            InitializeComponent();
        }

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void btnSalvarModelo(object sender, EventArgs e)
        {
            //TODO - pegar os dados da tela e criar o modelo

            ModeloNota modelo = new ModeloNota();
            modelo.Nome = Nome.Text;

            //TODO - Validação dos dados

            if (await ValidacaoAsync(modelo))
            {
                //TODO - Salvar o modelo no banco
                if (await new Repository().CadastrarAsync(modelo))
                {

                    MessagingCenter.Send<PageCadastroNotas, ModeloNota>(new PageCadastroNotas(), "onModeloNotaCadastrado", modelo);
                    await Navigation.PopModalAsync();
                }
            }
          

            //TODO - MessagingCenter retornar a tarefa na tela de listar
        }

        private async Task<bool> ValidacaoAsync(ModeloNota modelo)
        {
            return await Task.FromResult(true);
        }
    }
}