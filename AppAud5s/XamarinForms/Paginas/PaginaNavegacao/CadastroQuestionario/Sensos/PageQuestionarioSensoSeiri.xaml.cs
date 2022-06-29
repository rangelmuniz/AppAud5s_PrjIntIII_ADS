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
    public partial class PageQuestionarioSensoSeiri : ContentPage
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



        List<CheckList> listaitem { get; set; } = new List<CheckList>();


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
        
        
        
        public PageQuestionarioSensoSeiri()
        {
            InitializeComponent();
            AtualizaListaPergunta();
         
            
        }

        public PageQuestionarioSensoSeiri(Questionario aQuestionario)
        {
            InitializeComponent();
            Questionario = aQuestionario;
            AtualizaListaPergunta();

        }


        public void AtualizaListaPergunta()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<Pergunta>(
                        await new RepositoryPergunta().PesquisarToModeloSensoAsync(Questionario.Id_Modelo_Pergunta, 1)
                 );
                    cvListaPerguntasSeiri.ItemsSource = Lista;
                });
            });
        }

        private void AtualizaDados(object sender, EventArgs e)
        {

        }

        private void btnProximoSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaNavegacao.CadastroQuestionario.Sensos.PageQuestionarioSensoSeiton(Questionario));
        }

        private void BtnSalvar(object sender, EventArgs e)
        {
            QuestionarioSenso questionarioSenso = new QuestionarioSenso(); 

            double Peso = (20 / Lista.Count);
            
            foreach (Pergunta pergunta in Lista)
            {
                questionarioSenso.Id_Questionario = Questionario.Id;
                questionarioSenso.Id_Senso = pergunta.Id_Senso;
                questionarioSenso.Peso = Peso;                
                //questionarioSenso.Conforme = 
                questionarioSenso.Obeservacao = "ND";
           

            }
        }

  
    }
}