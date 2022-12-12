using DavidExamen1_1.Interfaces;
using DavidExamen1_1.Models;
using DavidExamen1_1.Services;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavidExamen1_1.DAO
{
    public class PoblacioDAO : IDAO<Poblacio>
    {
        private static PoblacioDAO _instance = null;
        public static PoblacioDAO Instance
        {
            get
            {
                if (_instance != null) { return _instance; }
                else
                {
                    _instance = new PoblacioDAO();
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Obte un objecte Poblacio de la base de dades.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat el Poblacio.</exception>
        public async Task<Poblacio> GetAsync(int id)
        {
            try
            {
                return await DataBase.connection.GetAsync<Poblacio>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Actualitza un objecte Poblacio de la base de dades.
        /// </summary>
        /// <param name="poblacio"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha actualitzat la Poblacio.</exception>
        public async Task SaveAsync(Poblacio poblacio)
        {
            if (await DataBase.connection.InsertOrReplaceAsync(poblacio) <= 0)
            {
                throw new Exception("No se ha modificat");
            }
        }

        /// <summary>
        /// Esborra una Poblacio de la base de dades.
        /// </summary>
        /// <param name="poblacio"></param>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha esborrat la Poblacio.</exception>
        public async Task DeleteAsync(Poblacio poblacio)
        {
            if (await DataBase.connection.DeleteAsync(poblacio) <= 0)
            {
                throw new Exception("No s'ha borrart");
            }
        }

        /// <summary>
        /// Obte una llista en totes les Poblacio de la base de dades.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">No s'ha trobat Poblacions.</exception>
        public async Task<List<Poblacio>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Poblacio>();
        }

        public async Task<List<Poblacio>> GetAllWitchChildrenAsync(int id)
        {
            Task<List<Poblacio>> ll = DataBase.connection.GetAllWithChildrenAsync<Poblacio>
                (
                x => x.Provincia.Id == id, recursive: true
                );
            return await ll;
        }
    }
}
