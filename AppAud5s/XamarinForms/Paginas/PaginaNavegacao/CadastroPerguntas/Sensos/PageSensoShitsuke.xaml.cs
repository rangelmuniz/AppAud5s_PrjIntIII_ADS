using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroPerguntas.Sensos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSensoShitsuke : ContentPage
    {
        public PageSensoShitsuke()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void VoltarSenso(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}