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
    public partial class PageQuestionarioSensoSeiton : ContentPage
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

        public PageQuestionarioSensoSeiton()
        {
            InitializeComponent();
            AtualizaListaPergunta();
        }

        public PageQuestionarioSensoSeiton(Questionario aQuestionario)
        {
            InitializeComponent();
            Questionario = aQuestionario;
            AtualizaListaPergunta();
        }

        private void AtualizaDados(object sender, EventArgs e)
        {

        }

        private void btnProximoSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaNavegacao.CadastroQuestionario.Sensos.PageQuestionarioSensoSeiso(Questionario));
        }

        public void AtualizaListaPergunta()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Pergunta>(
                        await new RepositoryPergunta().PesquisarToModeloSensoAsync(Questionario.Id_Modelo_Pergunta, 2)
                 );
                    cvListaPerguntasSeiton.ItemsSource = Lista;
                });
            });
        }
    }
}