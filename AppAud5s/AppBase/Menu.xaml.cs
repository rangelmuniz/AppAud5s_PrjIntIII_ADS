using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAud5s.AppBase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    public partial class Menu : MasterDetailPage
    {
        public Menu()       
        {
            InitializeComponent();
        }

        private void GetPaginaCadastroPerguntas(object sender, EventArgs e)        {

            ((MasterDetailPage)App.Current.MainPage).Detail = new AppAud5s.XamarinForms.Paginas.PaginaNavegacao.PageCadastroPerguntas();
            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;
        }
    }
}