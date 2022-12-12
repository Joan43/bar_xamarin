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
        // standalone = sol un objecte del tipus AlumneDAO
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
        /// Esborra provincia
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Provincia pro)
        {

            try
            {
                await DataBase.connection.DeleteAsync(pro, true);
            }
            catch (Exception e)
            {
                throw new Exception("El registre no s'ha esborrat");
            }
        }
        /// <summary>
        /// Obte totes les provincies
        /// </summary>
        /// <returns></returns>
        public async Task<List<Provincia>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Provincia>();
        }
        /// <summary>
        /// Obte un objecte provincia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Actualitza un objecte provincia
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
    }
}
