using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DavidExamen1_1.Models
{
    [Table("Poblacio")]
    public class Poblacio : ModelBase
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }

        private String _nom;
        public String Nom { get { return _nom; } set { _nom = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Provincia))]
        public int ProvinciaId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeDelete)]

        public Provincia Provincia { get { return _provincia; } set { _provincia = value; OnPropertyChanged(); } }
        private Provincia _provincia;

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Alumne> Alumnes { get; set; }

        public Poblacio(int id, String nom, Provincia provincia)
        {
            _id = id;
            _nom = nom;
            _provincia = provincia;
        }
        public Poblacio()
        {

        }
    }
}
