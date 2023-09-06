using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Articulos
    {
        public int nroArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marcas Marcas { get; set; }
        public Categorias Categoria { get; set; }
        public decimal Precio { get; set; }
    }
}
