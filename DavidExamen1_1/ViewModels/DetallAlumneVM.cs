using DavidExamen1_1.DAO;
using DavidExamen1_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DavidExamen1_1.ViewModels
{
    public class DetallAlumneVM : ViewModelBase
    {
        //LLISTA DE PROVINCIES
        private List<Provincia> _provincies;
        public List<Provincia> Provincies { get { return _provincies; } set { _provincies = value; OnPropertyChanged(); } }

        //LLISTA DE POBLACIONES
        private List<Poblacio> _poblaciones;
        public List<Poblacio> Poblaciones { get { return _poblaciones; } set { _poblaciones = value; OnPropertyChanged(); } }

        //OBJECTE ALUMNE DE LA CLASE, QUE ENS PASARA LA LLISTA
        private Alumne _alumneDetall;
        public Alumne AlumneDetall { get { return _alumneDetall; } set { _alumneDetall = value; OnPropertyChanged(); } }

        public DetallAlumneVM(Alumne a)
        {

            //EL ALUMNO INTERNO SERA EL DEL CONSTRCUTOR
            AlumneDetall = a;

            //LLENAMOS LA LISTA DE PROVINCIAS
            ProvinciasDAO.Instance.GetAllAsync().ContinueWith(
                x =>
                {
                    List<Provincia> ll = x.Result;
                    Provincies = new List<Provincia>(ll);
                }
                );

            //LLENAMOS LA LISTA DE PROVINCIAS
            PoblacioDAO.Instance.GetAllAsync().ContinueWith(
                x =>
                {
                    List<Poblacio> ll = x.Result;
                    Poblaciones = new List<Poblacio>(ll);
                }
                );

            //Task<List<Provincia>> tprovincia = ProvinciasDAO.Instance.GetAllAsync();
            //ObservableCollection<Provincia> Provincies = new ObservableCollection<Provincia>(tprovincia.Result);
            //Task<List<Poblacio>> tpoblaciones = PoblacioDAO.Instance.GetAllAsync();
            //ObservableCollection<Poblacio> Poblaciones = new ObservableCollection<Poblacio>(tpoblaciones.Result);
        }

        public async Task DeleteAsync()
        {
            try
            {
                await AlumnesDAO.Instance.DeleteAsync(AlumneDetall);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
