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

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas.Sensos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSensoShitsuke : ContentPage
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Desc_Pergunta")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Pergunta> _lista;

        public ObservableCollection<Pergunta> Lista
        {
            get
            {
                return _lista;
            }
            set
            {
                _lista = value;
                NotifyPropertyChanged("Lista");
            }
        }


        private int _idModeloPergunta;

        public int IdModeloPergunta
        {
            get
            {
                return _idModeloPergunta;
            }
            set
            {
                _idModeloPergunta = value;
            }
        }

        public PageSensoShitsuke()
        {
            InitializeComponent();
            AtualizaListaPergunta();
        }

        public PageSensoShitsuke(int aIdModeloPergunta)
        {
            InitializeComponent();
            IdModeloPergunta = aIdModeloPergunta;
            AtualizaListaPergunta();

        }

        private async void btnfinaliza(object sender, EventArgs e)
        {
          await Navigation.PopToRootAsync();
        }

        private void BtnCadastrarPerguntaSeiketsu(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PaginaNavegacao.CadastroPerguntas.Sensos.CadastroPerguntaSenso(IdModeloPergunta, 5, "SHITSUKE"));
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizaListaPergunta();
        }

        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certezaa que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem)sender;
                Pergunta perguntaShitsuke = (Pergunta)swipe.CommandParameter;
                var excluido = await new RepositoryPergunta().ExcluirAsync(perguntaShitsuke.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(perguntaShitsuke);
                }

            }
        }

        public void AtualizaListaPergunta()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Pergunta>(
                        await new RepositoryPergunta().PesquisarToModeloSensoAsync(IdModeloPergunta, 5)
                 );
                    cvListaPerguntaShitsuke.ItemsSource = Lista;
                });
            });
        }

    }
}