using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public  class Categorias
    {
        public Categorias()
        {

        }
        public Categorias(int Id, string Desc)
        {
            Descripcion = Desc;
            this.Id = Id;
        }
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
