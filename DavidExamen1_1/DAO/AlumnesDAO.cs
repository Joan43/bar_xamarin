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
        // standalone = sol un objecte del tipus AlumneDAO
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
        /// Esborra alumne.
        /// </summary>
        /// <param name="alumne"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha esborrat</exception>
        public async Task DeleteAsync(Alumne alumne)
        {
            if (await DataBase.connection.DeleteAsync(alumne) <= 0)
            {
                throw new Exception("No s'ha borrart");
            }
        }
        /// <summary>
        /// Obte un objecte alumne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Obte tots els alumnes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Alumne>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Alumne>();
        }
        /// <summary>
        /// Actualitza un objecte alumne
        /// </summary>
        /// <param name="alumne"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task SaveAsync(Alumne alumne)
        {
            if (await DataBase.connection.InsertOrReplaceAsync(alumne) <= 0)
            {
                throw new Exception("No se ha modificat");
            }
        }
    }
}
