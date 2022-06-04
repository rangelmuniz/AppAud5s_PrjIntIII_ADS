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
    public partial class PageSensoSeiton : ContentPage
    {
        public PageSensoSeiton()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void AvancaSenso(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageSensoSeiso());
        }

        private void VoltarSenso(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }
    }
}