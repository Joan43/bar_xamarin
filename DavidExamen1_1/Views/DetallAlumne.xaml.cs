using DavidExamen1_1.Models;
using DavidExamen1_1.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DavidExamen1_1.Views
{

    public partial class DetallAlumne : ContentPage
    {

        private DetallAlumneVM vm;

        public DetallAlumne(Alumne a)
        {
            vm = new DetallAlumneVM(a);
            //BINDING CONTEXT
            BindingContext = vm;
            InitializeComponent();
        }
        /*
        private void ClickedNou(object sender, EventArgs e)
        {
            vm.AlumneDetall = new Alumne();
            nou = true;
            if (BaseDades.NouAlumne(vm.AlumneDetall))
            {
                DisplayAlert("INFO", "Alumne afegit amb exit", "OK");
            }
            else
            {
                DisplayAlert("ERROR", "El alumne ja existeix en la BBDD", "OK");
            }
        }
        
        private void ClickedEsborra(object sender, EventArgs e)
        {
            vm.DeleteAsync();
            if (true)
            {
                DisplayAlert("INFO", "Alumne borrat amb exit", "OK");
            }
            else
            {
                DisplayAlert("ERROR", "El alumne no existeix en la BBDD", "OK");
            }

        }
        */
        private void tornarPobles(object sender, EventArgs e)
        {

        }

        private void ClickedNou(object sender, EventArgs e)
        {

        }

        private void ClickedEsborra(object sender, EventArgs e)
        {

        }

        private async void BorrarPoblacioAsync(short id)
        {
            try
            {
                await vm.BorraPoblacioAsync(Convert.ToInt16(idpoblacio.Text));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }

        private void ClickedBorrarPoblacioAsync(object sender, EventArgs e)
        {
            BorrarPoblacioAsync(Convert.ToInt16(idpoblacio.Text));
        }
        /*
private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
{
Poblacio poble = (Poblacio)e.Item;
vm.AlumneDetall.Poblacio = poble;
}
*/
    }
}