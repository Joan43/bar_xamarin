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
        /// 
        /// </summary>
        /// <param name="ponlacio"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Poblacio ponlacio)
        {

            try
            {
                await DataBase.connection.DeleteAsync(ponlacio, true);
            }
            catch (Exception e)
            {
                throw new Exception("El registre no s'ha esborrat");
            }
        }

        public async Task<List<Poblacio>> GetAllAsync()
        {
            return await DataBase.connection.GetAllWithChildrenAsync<Poblacio>();
        }

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

        public async Task SaveAsync(Poblacio poblacio)
        {
            if (await DataBase.connection.InsertOrReplaceAsync(poblacio) <= 0)
            {
                throw new Exception("No se ha modificat");
            }
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
