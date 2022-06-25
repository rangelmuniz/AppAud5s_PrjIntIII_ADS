using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.XamarinForms.Paginas.PaginaNavegacao.CadastroNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVisualizarIndicador : ContentPage
    {
        public PageVisualizarIndicador()
        {
            InitializeComponent();
        }     

        private void Voltar(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}