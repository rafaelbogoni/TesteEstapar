using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Estapar.Data
{
    public class EstaparContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EstaparContext() : base("name=EstaparContext")
        {
        }

        public System.Data.Entity.DbSet<TesteEstapar.Models.MotoristaEntity> MotoristaEntities { get; set; }

        public System.Data.Entity.DbSet<TesteEstapar.Models.CarroEntity> CarroEntities { get; set; }

        public System.Data.Entity.DbSet<TesteEstapar.Models.ResponsavelEntity> ResponsavelEntities { get; set; }
    }
}
