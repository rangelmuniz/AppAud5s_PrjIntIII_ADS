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

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroQuestionario.Sensos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQuestionarioSensoShitsuke : ContentPage
    {
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
            }
        }


        private Questionario _questionario;

        public Questionario Questionario
        {
            get
            {
                return _questionario;
            }
            set
            {
                _questionario = value;
            }
        }

        public PageQuestionarioSensoShitsuke()
        {
            InitializeComponent();
            AtualizaListaPergunta();
        }

        public PageQuestionarioSensoShitsuke(Questionario aQuestionario)
        {
            InitializeComponent();
            Questionario = aQuestionario;
            AtualizaListaPergunta();
        }

        private void AtualizaDados(object sender, EventArgs e)
        {

        }

  

        public void AtualizaListaPergunta()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Pergunta>(
                        await new RepositoryPergunta().PesquisarToModeloSensoAsync(Questionario.Id_Modelo_Pergunta, 4)
                 );
                    cvListaPerguntasShitsuke.ItemsSource = Lista;
                });
            });
        }

        private void btnFinalizar(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}