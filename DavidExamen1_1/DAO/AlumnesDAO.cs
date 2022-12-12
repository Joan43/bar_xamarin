using DavidExamen1_1.Interfaces;
using DavidExamen1_1.Models;
using DavidExamen1_1.Services;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavidExamen1_1.DAO
{
    public class AlumnesDAO : IDAO<Alumne>
    {
        private static AlumnesDAO _instance = null;
        public static AlumnesDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new AlumnesDAO();
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Obte un objecte Alumne de la base de dades.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat el Alumne.</exception>
        public async Task<Alumne> GetAsync(int id)
        {
            try
            {
                return await DataBase.connection.GetAsync<Alumne>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Actualitza un objecte Alumne de la base de dades.
        /// </summary>
        /// <param name="alumne"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha actualitzat el Alumne.</exception>
        public async Task SaveAsync(Alumne alumne)
        {
            if (await DataBase.connection.InsertOrReplaceAsync(alumne) <= 0)
            {
                throw new Exception("No se ha modificat");
            }
        }

        /// <summary>
        /// Esborra un Alumne de la base de dades.
        /// </summary>
        /// <param name="alumne"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha esborrat el Alumne.</exception>
        public async Task DeleteAsync(Alumne alumne)
        {
            if (await DataBase.connection.DeleteAsync(alumne) <= 0)
            {
                throw new Exception("No s'ha borrart");
            }
        }

        /// <summary>
        /// Obte una llista en tots els Alumnes de la base de dades.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat Alumnes.</exception>
        public async Task<List<Alumne>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Alumne>();
        }
    }
}
