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

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroNotas : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Nome")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ModeloNota> _lista;

        public ObservableCollection<ModeloNota> Lista
        {
            get {
                return _lista;
            }
            set {
                _lista = value;
                NotifyPropertyChanged("Lista");
            }
        }


        public PageCadastroNotas()
        {
            InitializeComponent();            

            MessagingCenter.Subscribe<PageCadastroPerguntas, ModeloNota>(this, "onModeloNotaCadastrado", (PageCadastroNotas, modelo) =>
            {
                if (Lista != null)
                {
                    Lista.Add(modelo);
                }

            });

            AtualizarListaModelo();
        }

        //public PageCadastroNotas(ModeloNota modelo) 
        //{
        //    InitializeComponent();

        //    BindingContext = modelo;
        //}

        private void BtnCadastrarModeloNota(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new XamarinForms.Paginas.PaginaNavegacao.CadastroNotas.CadastroModeloNotas());
        }

        private void AtualizarListaModelo()
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Lista = new ObservableCollection<ModeloNota>(
                        await new Repository().PesquisarAsync()
                 );
                    cvListaModelos.ItemsSource = Lista;
                });
            });
        }


        private async void BtnExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Tem certezaa que deseja excluir este modelo?", "Sim", "Não");

            if (pergunta)
            {
                //TODO - Excluir Modelo do banco
                var swipe = (SwipeItem) sender;
               ModeloNota modelo = (ModeloNota)swipe.CommandParameter;
                var excluido = await new Repository().ExcluirAsync(modelo.Id);

                //TODO - Excluir da lista    
                if (excluido)
                {
                    Lista.Remove(modelo);
                }
                
            }
        }

        private void AbreCadastroNotasIndicador(object sender, EventArgs e)
        {
            var evento = (TappedEventArgs)e;
            var modelo = (ModeloNota)evento.Parameter;

            Navigation.PushModalAsync(new XamarinForms.Paginas.PaginaNavegacao.CadastroNotas.CadastrarIndicadorNota(modelo));
        }

        private void AtualizaDados(object sender, EventArgs e)
        {
            AtualizarListaModelo();
        }
    }
}