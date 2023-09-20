using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.RasteBazar.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Migrations
{
    [NopMigration("2020/05/27 08:40:55:1687541", "Other.ProductViewTracker base schema", MigrationProcessType.Installation)]
    public class AddCheckTableMigrationMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<Check>();
        }
    }
}
