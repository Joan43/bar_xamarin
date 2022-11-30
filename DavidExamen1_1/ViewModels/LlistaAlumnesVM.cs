using DavidExamen1_1.DAO;
using DavidExamen1_1.Helpers;
using DavidExamen1_1.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DavidExamen1_1.ViewModels
{
    public class LlistaAlumnesVM : Base
    {
        private ObservableCollection<Alumne> _BindingAlumnes;
        public ObservableCollection<Alumne> BindingAlumnes
        {
            get { return _BindingAlumnes; }
            set
            {
                _BindingAlumnes = value;
                OnPropertyChanged();
            }
        }
        public LlistaAlumnesVM()
        {
            AlumnesDAO.Instance.GetAllAsync().ContinueWith(
                x =>
                {
                    List<Alumne> ll = x.Result;
                    BindingAlumnes = new ObservableCollection<Alumne>(ll);
                }
                );
        }
    }
}
