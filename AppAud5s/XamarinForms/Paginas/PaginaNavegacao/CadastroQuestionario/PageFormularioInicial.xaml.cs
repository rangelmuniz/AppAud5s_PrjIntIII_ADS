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

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFormularioInicial : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Id")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        


        ObservableCollection<Questionario> _lista;


        ObservableCollection<Questionario> Lista
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



        private ModeloPergunta _modeloPergunta;

        public ModeloPergunta ModeloPergunta
        {
            get 
            { 
                return  _modeloPergunta; 
            }
            set 
            { 
                _modeloPergunta = value; 
            }    
        }
        
        
        
        public PageFormularioInicial()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<PageFormularioInicial, Questionario>(this, "onDadosCadastrados", (PageFormularioInicial, questionario) =>
            {
                if (Lista != null)
                {
                    Lista.Add(questionario);
                }

            });

            AtualizarListaDados();
        }

        public PageFormularioInicial(ModeloPergunta modeloPergunta)
        {
            InitializeComponent();
            ModeloPergunta = modeloPergunta;
            AtualizarListaDados();
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizarListaDados();
        }

        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certezaa que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem)sender;
                Questionario questionario = (Questionario)swipe.CommandParameter;
                var excluido = await new RepositoryQuestionario().ExcluirAsync(questionario.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(questionario);
                }

            }

        }

        private void BtnCadastrarDadosQuetionario(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PaginaNavegacao.CadastroQuestionario.PageCadastroDadosQuestionario(ModeloPergunta.Id));
        }



        private void AtualizarListaDados()
        {

            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Questionario>(
                        await new RepositoryQuestionario().PesquisarToModeloPerguntaAsync(ModeloPergunta.Id)
                 );
                    cvListaDadosQuestionario.ItemsSource = Lista;
                });
            });
        }

        private void AbreQuestionarioSensoSeiri(object sender, EventArgs e)
        {
            var evento = (TappedEventArgs)e;
            var questionario = (Questionario)evento.Parameter;

            Navigation.PushAsync(new PaginaNavegacao.CadastroQuestionario.Sensos.PageQuestionarioSensoSeiri(questionario));
        }
    }
}