using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace DavidExamen1_1.Models
{
    [Table("Provincia")]
    public class Provincia : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        private int _id;

        private String _nom;
        public String Nom { get { return _nom; } set { _nom = value; OnPropertyChanged(); } }

        [OneToMany]
        public List<Poblacio> Poblacions { get; set; }

        public Provincia(int id, String nom)
        {
            _id = id;
            _nom = nom;
        }
        public Provincia()
        {

        }
    }
}
