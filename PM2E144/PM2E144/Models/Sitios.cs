using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E144.Models
{
   public  class Sitios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public byte[] Imagen { get; set; }
        public Int32 Latitud { get; set; }

        public Int32 Longitud { get; set; }

        [MaxLength (100)]
        public String Descripcion { get; set; }
        
    }
}
