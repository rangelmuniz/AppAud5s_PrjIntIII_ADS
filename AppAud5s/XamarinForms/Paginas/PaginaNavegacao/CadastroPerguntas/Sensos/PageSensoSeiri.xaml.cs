using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppAud5s.BancoDados;
using AppAud5s.Model;
using AppAud5s.XamarinForms.Exceptions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas.Sensos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSensoSeiri : ContentPage
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
            get { 
                return _idModeloPergunta;
            }
            set
            {
                _idModeloPergunta = value;
            }   
        }
        
        public PageSensoSeiri()
        {
            InitializeComponent();
            AtualizaListaPergunta();
        }

        public PageSensoSeiri(int aIdModeloPergunta)
        {
            InitializeComponent();
            IdModeloPergunta = aIdModeloPergunta;
            AtualizaListaPergunta();
            
            
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizaListaPergunta();
        }

        public void AtualizaListaPergunta()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Pergunta>(
                        await new RepositoryPergunta().PesquisarToModeloSensoAsync(IdModeloPergunta, 1)
                 );
                    cvListaPerguntaSeiri.ItemsSource = Lista;
                });
            });
        }

        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certezaa que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem)sender;
                Pergunta perguntaseiri = (Pergunta)swipe.CommandParameter;
                var excluido = await new RepositoryPergunta().ExcluirAsync(perguntaseiri.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(perguntaseiri);
                }

            }

        }

        private void BtnCadastrarPerguntaSeiri(object sender, EventArgs e)
        {         
           Navigation.PushModalAsync(new PaginaNavegacao.CadastroPerguntas.Sensos.CadastroPerguntaSenso(IdModeloPergunta, 1, "SEIRI"));           
          
        }

        private void btnProximoSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaNavegacao.CadastroPerguntas.Sensos.PageSensoSeiton(IdModeloPergunta));
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    return true;
        //} 


    }
}