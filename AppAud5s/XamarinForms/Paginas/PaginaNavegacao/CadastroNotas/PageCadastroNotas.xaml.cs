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
    public partial class PageCadastroNotas : ContentPage
    {
        public PageCadastroNotas()
        {
            InitializeComponent();
        }

        private void BtnCadastrarModeloNota(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new XamarinForms.Paginas.PaginaNavegacao.CadastroNotas.CadastroModeloNotas());
        }

        private void AbreCadastroNotasIndicador(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new XamarinForms.Paginas.PaginaNavegacao.CadastroNotas.CadastrarIndicadorNota());
        }
    }
}