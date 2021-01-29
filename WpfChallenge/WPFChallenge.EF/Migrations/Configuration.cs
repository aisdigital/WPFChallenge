using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFChallenge.EF.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"ServicosExternos/PersistenciaViaEntityFramework/Migrations";
        }

    }
}
