using DavidExamen1_1.Interfaces;
using DavidExamen1_1.Models;
using DavidExamen1_1.Services;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavidExamen1_1.DAO
{
    public class ProvinciasDAO : IDAO<Provincia>
    {
        private static ProvinciasDAO _instance = null;
        public static ProvinciasDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new ProvinciasDAO();
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Obte una Provincia de la base de dades.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat la Provincia.</exception>
        public async Task<Provincia> GetAsync(int id)
        {
            try
            {
                return await DataBase.connection.GetAsync<Provincia>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Actualitza un objecte Provincia de la base de dades.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task SaveAsync(Provincia obj)
        {
            if (await DataBase.connection.InsertOrReplaceAsync(obj) <= 0)
            {
                throw new Exception("No se ha modificat");
            }
        }

        /// <summary>
        /// Esborra Provincia de la base de dades.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Provincia pro)
        {
            if (await DataBase.connection.DeleteAsync(pro) <= 0)
            {
                throw new Exception("No s'ha borrart");
            }
        }

        /// <summary>
        /// Obte una llista en totes les Provincies de la base de dades.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat Provincies.</exception>
        public async Task<List<Provincia>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Provincia>();
        }
    }
}
