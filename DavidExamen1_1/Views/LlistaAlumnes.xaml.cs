using DavidExamen1_1.Models;
using DavidExamen1_1.ViewModels;
using Xamarin.Forms;

namespace DavidExamen1_1.Views
{
    public partial class LlistaAlumnes : ContentPage
    {
        private LlistaAlumnesVM vm;

        public LlistaAlumnes()
        {
            InitializeComponent();
            vm = new LlistaAlumnesVM();
            //BINDING CONTEXT
            BindingContext = vm;
        }

        //METODO QUE SE HACE AL PULSAR UN ALUMNO
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //CUANDO PULSAMOS UNO DE LA LISTA, RECOGEMOS ESE OBJETO
            Alumne alumne = (Alumne)e.Item;

            if (alumne == null)
                return;

            //CUANDO LO RECOGEMOS, ABRIMOS LA VISTA DE DETALLE, PASANDOLE ESE OBJETO
            await Navigation.PushAsync(new DetallAlumne(alumne));
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}