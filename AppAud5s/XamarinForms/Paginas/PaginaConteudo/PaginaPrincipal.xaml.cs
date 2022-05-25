using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaConteudo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void AbreCadastroNota(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.PaginaNavegacao.PageCadastroNotas());
        }

        private void AbreCadastroPergunta(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.PaginaNavegacao.PageCadastroPerguntas());

        }

        private void AbreQuestionario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.PaginaNavegacao.PageQuestionario());
        }
    }
}