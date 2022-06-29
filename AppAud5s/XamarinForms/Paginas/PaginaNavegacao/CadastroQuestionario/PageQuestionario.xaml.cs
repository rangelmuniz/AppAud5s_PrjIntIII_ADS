using AppAud5s.BancoDados;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQuestionario : ContentPage
    {

        private ObservableCollection<ModeloPergunta> _lista;
        public ObservableCollection<ModeloPergunta> Lista
        {
            get
            {
                return _lista;
            }
            set
            {
                _lista = value;            
            }
        }


        public PageQuestionario()
        {
            InitializeComponent();
            AtualizarListaModelo();
        }

        private void btnOpenFormularioInicial(object sender, EventArgs e)
        {
            var evento = (TappedEventArgs)e;
            var modelo = (ModeloPergunta)evento.Parameter;

            Navigation.PushAsync(new PaginaNavegacao.CadastroQuestionario.PageFormularioInicial(modelo));
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizarListaModelo();
        }

        private void AtualizarListaModelo()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<ModeloPergunta>(
                        await new RepositoryModeloPergunta().PesquisarAsync()
                 );
                    cvListaModeloPerguntas.ItemsSource = Lista;
                });
            });
        }

    }
}