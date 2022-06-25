using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroPerguntas : ContentPage
    {
        public PageCadastroPerguntas()
        {
            InitializeComponent();

            //Imagem01.Source = ImageSource.FromResource("AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas.metodologiaCincoS.png"); 

        }

     

        private void VoltarPaginaAnterior(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void GetTelaListarPerguntas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaNavegacao.CadastroPerguntas.ListarPerguntas());
        }

        private void BtnGetCadastroModeloPergunta(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PaginaNavegacao.CadastroPerguntas.CadastroModeloPergunta());
        }
    }
}