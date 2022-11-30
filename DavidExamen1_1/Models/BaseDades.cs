using System;
using System.Collections.Generic;
using System.Text;

namespace DavidExamen1_1.Models
{
    public class BaseDades
    {
        public static List<Provincia> LlistaProvincies;
        public static List<Poblacio> LlistaPoblacions;
        public static List<Alumne> LlistaAlumnes;

        public static List<Poblacio> TraurePoblesProvincia(Provincia p)
        {
            List<Poblacio> lista = new List<Poblacio>();
            foreach (Poblacio z in LlistaPoblacions)
            {
                if (z.Provincia.Id == p.Id)
                {
                    lista.Add(z);
                }
            }
            return lista;
        }

        //AFEGIR ALUMNE
        public static Boolean NouAlumne(Alumne nou)
        {
            Boolean trobat = false;
            foreach (Alumne a in LlistaAlumnes)
            {
                if (a.Id == nou.Id)
                {
                    trobat = true;
                    break;
                }
            }
            if (!trobat)
            {
                LlistaAlumnes.Add(nou);
                return true;
            }
            else
            {
                return false;
            }
        }

        //BORRAR ALUMNE
        public static Boolean BorrarAlumne(Alumne alu)
        {
            if (LlistaAlumnes.Contains(alu))
            {
                LlistaAlumnes.Remove(alu);
                return true;
            }
            else
            {
                return false;
            }
        }

        static BaseDades()
        {
            LlistaProvincies = new List<Provincia>();
            Provincia valencia = new Provincia(1, "Valencia");
            Provincia castello = new Provincia(2, "Castelló");
            LlistaProvincies.Add(valencia);
            LlistaProvincies.Add(castello);

            LlistaPoblacions = new List<Poblacio>();    
            Poblacio alberic = new Poblacio(1,"Alberic", valencia);
            Poblacio alzira = new Poblacio(2, "Alzira", valencia);
            Poblacio vilareal = new Poblacio(3, "Vilareal",castello);
            LlistaPoblacions.Add(alzira);
            LlistaPoblacions.Add(alberic);
            LlistaPoblacions.Add(vilareal);

            LlistaAlumnes = new List<Alumne>();
            Alumne josep=new Alumne(1,"Josep","Estarlich","Oliver",alberic);
            Alumne neus = new Alumne(2, "Neus", "Estruch", "Perales",alzira);
            Alumne ximo = new Alumne(3, "Ximo", "Navarres", "Teuladi", vilareal);

            LlistaAlumnes.Add(josep);
            LlistaAlumnes.Add(neus);
            LlistaAlumnes.Add(ximo);
        }
    }
}
