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
    public partial class PageSensoSeiketsu : ContentPage
    {
        public PageSensoSeiketsu()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void AvancaSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageSensoShitsuke());
        }

        private void VoltarSenso(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}