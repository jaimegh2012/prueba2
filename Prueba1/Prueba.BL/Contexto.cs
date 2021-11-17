using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDB)\MSSQLLocalDB;attachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\pruebaDB.mdf")
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}

