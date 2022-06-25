using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAud5s.BancoDados;
using AppAud5s.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppAud5s.XamarinForms.Exceptions;
using System.Collections.ObjectModel;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas.Sensos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPerguntaSenso : ContentPage
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



        private int _idModeloPergunta;

        public int IdModeloPergunta
        {
            get 
            { 
                return _idModeloPergunta; 
            }
            set { 
                _idModeloPergunta = value; 
            }
        }

        private int _idSenso;

        public int IdSenso
        {
            get 
            { 
                return _idSenso; 
            }
            set 
            { 
                _idSenso = value;
            }
        }

        private string _NomeSenso;

        public string NomeSenso
        {
            get 
            { 
                return _NomeSenso;
            }
            set 
            { 
                _NomeSenso = value; 
            }
        }

        public CadastroPerguntaSenso()
        {
            InitializeComponent();       
        }

        public CadastroPerguntaSenso(int aIdModeloPergunta, int aIdSenso, string aNomeSenso)
        {
            InitializeComponent();
            IdModeloPergunta = aIdModeloPergunta;
            IdSenso = aIdSenso;
            NomeSenso = aNomeSenso;
        }

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void btnSalvarPergunta(object sender, EventArgs e)
        {
            var MaxNumero = 0;
            Lista = new ObservableCollection<Pergunta>(
                await new RepositoryPergunta().PesquisarToModeloSensoAsync(IdModeloPergunta, IdSenso)
            );

            if (Lista.Count > 0)
            {
                MaxNumero = await GetMaxNumeroPergunta(IdModeloPergunta, IdSenso);
                MaxNumero = MaxNumero + 1;
            }
            else
            {
                MaxNumero = 1;
            }

            try
            { 
                if (MaxNumero > 5)
                {
                    throw new DomainException("Número máximo de perguntas atingido.");
                }
                else
                {
                    Pergunta pergunta = new Pergunta();

                    pergunta.Id_Modelo_Pergunta = IdModeloPergunta;
                    pergunta.Id_Senso = IdSenso;
                    pergunta.Nome_Senso = NomeSenso;
                    pergunta.Numero_Pergunta = MaxNumero;
                    pergunta.Desc_Pergunta = desPergunta.Text;

                    if (await ValidacaoAsync(pergunta))
                    {
                        //TODO - Salvar o modelo no banco
                        if (await new RepositoryPergunta().CadastrarAsync(pergunta))
                        {
                            await Navigation.PopModalAsync();
                        }
                    }

                }
            }
            catch (DomainException ex)
            {
               await DisplayAlert("Atenção", "Erro: " + ex.Message, "OK");

            }
            finally
            {
                await Navigation.PopModalAsync();
            }


        }



        private async Task<bool> ValidacaoAsync(Pergunta pergunta)
        {
            return await Task.FromResult(true);
        }

        private async Task<int> GetMaxNumeroPergunta(int aIdModeloPergunta, int aIdSenso)
        {
            return await new RepositoryPergunta().ConsultarMaxNumeroPerguntaAsync(aIdModeloPergunta, aIdSenso);
        }


    }
}