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
    public partial class PageSensoSeiri : ContentPage
    {
        public PageSensoSeiri()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void VoltarPaginaAnterior(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void AvancaSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageSensoSeiton());
        }
    }
}