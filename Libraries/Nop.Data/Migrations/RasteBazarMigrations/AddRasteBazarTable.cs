using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;
using Nop.Core.Domain.Stores;

namespace Nop.Data.Migrations.RasteBazarMigrations
{
    [NopMigration("2022/01/01 12:00:00:2551770", "RasteBazar. Create Tabel", UpdateMigrationType.Data, MigrationProcessType.Installation)]
    public class AddRasteBazarTable : AutoReversingMigration
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            Create.Table("RasteBazar")
                .WithColumn("Id").AsInt32().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                .WithColumn("Title").AsString(255).Nullable()
                .WithColumn("MetaTitle").AsString(400).Nullable()
                .WithColumn("MetaKeywords").AsString(400).Nullable()
                .WithColumn("PictureId").AsInt32().Nullable();
            ////add column Id
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.Id)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.Id)).AsInt32().NotNullable();
            //}

            ////add column Name
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.Name)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.Name)).AsString(255).NotNullable();
            //}

            ////add column Description
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.Description)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.Description)).AsString(255).NotNullable();
            //}

            ////add column Title
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.Title)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.Title)).AsString(255).NotNullable();
            //}

            ////add column MetaTitle
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.MetaTitle)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.MetaTitle)).AsString(400).NotNullable();
            //}

            ////add column MetaKeywords
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.MetaKeywords)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.MetaKeywords)).AsAnsiString(400).NotNullable();
            //}

            ////add column PictureId
            //if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.PictureId)).Exists())
            //{
            //    Alter.Table(nameof(RasteBazar))
            //        .AddColumn(nameof(RasteBazar.PictureId)).AsInt32().NotNullable();
            //}
        }
    }
}
