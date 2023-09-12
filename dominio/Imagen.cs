using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int id { get; set; }
        public int idArticulo { get; set; }
        public string imagenUrl { get; set; }

        public static explicit operator Imagen(string v)
        {
            throw new NotImplementedException();
        }
    }
}