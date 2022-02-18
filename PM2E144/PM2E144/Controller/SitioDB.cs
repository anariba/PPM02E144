using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using PM2E144.Models;

namespace PM2E144.Controller
{
   public class SitioDB
    {
        readonly SQLiteAsyncConnection db;

        public SitioDB(){ }

        public SitioDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            // creacion d tablas de la base de datos
            db.CreateTableAsync<Sitios>();
        }

       
        //retorna la tabla sitios con una lista
        public Task<List<Sitios>> Listasitios()
        {
            return db.Table<Sitios>().ToListAsync();
        }


        //guardar un sitio
        public Task<Int32> guardar(Sitios sitio)
        {

            if (sitio.Id != 0)
            {
                return db.UpdateAsync(sitio);
            }
            else
            {
                return db.InsertAsync(sitio);
            }

        }

        //Eliminar sitio

        public Task<Int32> borrar(Sitios sitio)
        {
            return db.DeleteAsync(sitio);

        }

      

    }
}
