using AppAud5s.BancoDados;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroModeloPergunta : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Nome")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ModeloPergunta> _lista;

        public ObservableCollection<ModeloPergunta> Lista
        {
            get { 
                return _lista; 
            }
            set { _lista = value;
                NotifyPropertyChanged("Lista");
            }
        }
        


        public CadastroModeloPergunta()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<CadastroModeloPergunta, ModeloPergunta>(this, "onModeloPerguntaCadastrado", (CadastroModeloPergunta, modelo) =>
            {
                if (Lista != null)
                {
                    Lista.Add(modelo);
                }
            });
            AtualizarListaModelo();
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizarListaModelo();
        }

        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certezaa que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem)sender;
                ModeloPergunta modelo = (ModeloPergunta)swipe.CommandParameter;
                var excluido = await new RepositoryModeloPergunta().ExcluirAsync(modelo.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(modelo);
                }

            }
        }

            private void AbreCadastroPerguntasSensos(object sender, EventArgs e)
        {
            var evento = (TappedEventArgs)e;
            var modelo = (ModeloPergunta)evento.Parameter;

            Navigation.PushModalAsync(new PaginaNavegacao.CadastroPerguntas.Sensos.PageSensoSeiri(modelo.Id));
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


        private void BtnCadastrarModeloPergunta(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PaginaNavegacao.CadastroPerguntas.CadastrarModelo());
        }
    }
}