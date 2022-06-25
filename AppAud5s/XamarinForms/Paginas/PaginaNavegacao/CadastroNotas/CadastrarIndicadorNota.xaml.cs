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

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarIndicadorNota : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }   

        
        private ModeloNota modelo;        


        ObservableCollection<Indicador> _lista;
        

        ObservableCollection<Indicador> Lista
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

        private int _idModelo;

        public int IdModelo
        {
            get
            {
                return _idModelo;
            }
            set
            {
                _idModelo = value;
            }
        }

        public CadastrarIndicadorNota()
        {
            InitializeComponent();       

            MessagingCenter.Subscribe<CadastrarIndicadorNota, Indicador>(this, "onIndicadorCadastrado", (CadastrarIndicadorNota, indicador) =>
            {
                if (Lista != null)
                {
                    Lista.Add(indicador);
                }

            });

            AtualizarListaIndicador();
        }

        public CadastrarIndicadorNota(int aIdModelo)
        {
            InitializeComponent();
            IdModelo = aIdModelo;
            AtualizarListaIndicador();
        }

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnCadastrarNovoIndicador(object sender, EventArgs e)
        {
            //var evento = (TappedEventArgs)e;
            //var modelo = (ModeloNota)evento.Parameter;
           

            Navigation.PushModalAsync(new XamarinForms.Paginas.PaginaNavegacao.CadastroNotas.CadastroIndicador(IdModelo));
        }

        private void  AtualizarListaIndicador()
        {
           
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {                   
                    Lista = new ObservableCollection<Indicador>(
                        await new RepositoryIndicador().PesquisarAsync(IdModelo)
                 );
                    cvListaIndicador.ItemsSource = Lista;
                });
            });
        }

        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certeza que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem)sender;
                Indicador indicador = (Indicador)swipe.CommandParameter;
                var excluido = await new RepositoryIndicador().ExcluirAsync(indicador.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(indicador);
                }

            }
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizarListaIndicador();
        }
    }
}