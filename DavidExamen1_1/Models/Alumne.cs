using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace DavidExamen1_1.Models
{
    [Table("Alumne")]
    public class Alumne : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        private int _id;

        private String _name;
        public String Name { get { return _name;  } set { _name = value; OnPropertyChanged(); } }

        private String _surname1;
        public String Surname1 { get { return _surname1;  } set { _surname1 = value; OnPropertyChanged(); } }

        private String _surname2;
        public String Surname2 { get { return _surname2;  } set { _surname2 = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Poblacio))]
        public int PoblacioId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Poblacio Poblacio { get { return _poblacio;  } set { _poblacio = value; OnPropertyChanged(); } }
        private Poblacio _poblacio;

        public Alumne(int id,String name,String surname1,String surname2,Poblacio poblacio)
        {
            _id = id;
            _name = name;
            _surname1 = surname1;
            _surname2 = surname2;
            _poblacio = poblacio;    
        }
        public Alumne()
        {

        }
    }
}
