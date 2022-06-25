using AppAud5s.BancoDados;
using AppAud5s.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroIndicador : ContentPage
    {
        private ModeloNota modelo;

        private string _avaliacao;

        public string Avaliacao
        {
            get
            {
                return _avaliacao;
            }
            set
            {
                _avaliacao = value;

            }
        }

        private int _codmodelo;

        public int Codmodelo
        {
           get { return _codmodelo; 
            }
            set { _codmodelo = value; 
            }
        }

        public CadastroIndicador(int aCodModelo)
        {
            InitializeComponent();
            Codmodelo = aCodModelo;

        }
  

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OnChangeSeletor(object sender, EventArgs e)
        {
           var Picker = (Picker)sender;
            int ItemSelecionado = Picker.SelectedIndex;            
        
                switch (ItemSelecionado)
                {
                    case 0:
                        Picker.TextColor = Color.Red;
                        Avaliacao = "Ruim";
                    break;
                    case 1:
                        Picker.TextColor = Color.Yellow;
                        Avaliacao = "Media";
                    break;
                    case 2:
                        Picker.TextColor = Color.Blue;
                        Avaliacao = "Boa";
                    break;
                    case 3:
                        Picker.TextColor = Color.Green;
                        Avaliacao = "Otima";
                    break;
                    case 4:
                       Picker.SelectedIndex = -1;
                    break;
                default:
                       Picker.SelectedIndex = -1;
                    break;
                }
    
        }

        private async void BtnSalvarIndicador(object sender, EventArgs e)
        {
            //TODO - pegar os dados da tela e criar o modelo

            Indicador indicador = new Indicador();
            indicador.Id_Modelo = Codmodelo;
            indicador.Nota_Minima = int.Parse(NotaMinima.Text);
            indicador.Nota_Maxima = int.Parse(NotaMaxima.Text);
            indicador.Avaliacao = Avaliacao;          
            
            //TODO - Validação dos dados

            if (await ValidacaoAsync(indicador))
            {
                //TODO - Salvar o modelo no banco
                if (await new RepositoryIndicador().CadastrarAsync(indicador))
                {

                    MessagingCenter.Send<CadastrarIndicadorNota, Indicador>(new CadastrarIndicadorNota(), "onIndicadorCadastrado", indicador);
                    await Navigation.PopModalAsync();
               }
            }


            //TODO - MessagingCenter retornar a tarefa na tela de listar
        }

        private async Task<bool> ValidacaoAsync(Indicador indicador)
        {
            return await Task.FromResult(true);
        }
    }
}