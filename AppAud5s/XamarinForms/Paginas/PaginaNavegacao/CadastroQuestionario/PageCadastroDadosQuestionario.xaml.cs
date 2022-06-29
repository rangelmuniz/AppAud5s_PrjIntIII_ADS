using AppAud5s.BancoDados;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroQuestionario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroDadosQuestionario : ContentPage
    {
        private int _IdModeloPergunta;

        public int IdModeloPergunta
        {
            get
            {
                return _IdModeloPergunta;
            }
            set 
            { 
                _IdModeloPergunta = value; 
            }
        }   
        
        
        public PageCadastroDadosQuestionario()
        {
            InitializeComponent();
        }

        public PageCadastroDadosQuestionario(int aIdModeloPergunta)
        {
            InitializeComponent();
            IdModeloPergunta = aIdModeloPergunta;
        }



        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnSalvarDados(object sender, EventArgs e)
        {

            Questionario dadosQuestionario = new Questionario();
            dadosQuestionario.Id_Modelo_Pergunta = IdModeloPergunta;
            dadosQuestionario.Nome_Auditor = entNomeAuditor.Text;
            dadosQuestionario.Setor = entSetor.Text;
            dadosQuestionario.Data_Auditoria = dpDataAuditoria.Date;

            if (await ValidacaoAsync(dadosQuestionario))
            {
                //TODO - Salvar o modelo no banco
                if (await new RepositoryQuestionario().CadastrarAsync(dadosQuestionario))
                {

                    MessagingCenter.Send<PageFormularioInicial, Questionario>(new PageFormularioInicial(), "onDadosCadastrados", dadosQuestionario);
                    await Navigation.PopModalAsync();
                }
            }

        }

        private async Task<bool> ValidacaoAsync(Questionario questionario)
        {
            return await Task.FromResult(true);
        }
    }
}