using FluentMigrator;
using LinqToDB.DataProvider;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.RasteBazars;

namespace Nop.Data.Migrations.RasteBazarMigrations
{
    [NopMigration("2022/01/01 12:00:00:2551770", "RasteBazar. Update Tabel", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class UpdateRasteBazar : Migration
    {

        private readonly INopDataProvider _dataProvider;

        public UpdateRasteBazar(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            //Add rastebazar permisionrecord 
            if (!_dataProvider.GetTable<PermissionRecord>().Any(pr => string.Compare(pr.SystemName, "ManageRasteBazar", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                var multiFactorAuthenticationPermission = _dataProvider.InsertEntity(
                    new PermissionRecord
                    {
                        Name = "Admin area. Manage Raste Bazar",
                        SystemName = "ManageRasteBazar",
                        Category = "Catalog"
                    }
                );

                //add it to the Admin role by default
                var adminRole = _dataProvider
                    .GetTable<CustomerRole>()
                    .FirstOrDefault(x => x.IsSystemRole && x.SystemName == NopCustomerDefaults.AdministratorsRoleName);

                _dataProvider.InsertEntity(
                            new PermissionRecordCustomerRoleMapping
                            {
                                CustomerRoleId = adminRole.Id,
                                PermissionRecordId = multiFactorAuthenticationPermission.Id
                            }
                        );
            }

            //add column PageSize
            if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.PageSize)).Exists())
            {
                Alter.Table(nameof(RasteBazar))
                    .AddColumn(nameof(RasteBazar.PageSize)).AsInt32().Nullable();
            }

            //add column PageSizeOptions
            if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.PageSizeOptions)).Exists())
            {
                Alter.Table(nameof(RasteBazar))
                    .AddColumn(nameof(RasteBazar.PageSizeOptions)).AsString(255).Nullable();
            }

            //add column Deleted
            if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.Deleted)).Exists())
            {
                Alter.Table(nameof(RasteBazar))
                    .AddColumn(nameof(RasteBazar.Deleted)).AsBoolean().Nullable();
            }

            //add column CreatedOnUtc
            if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.CreatedOnUtc)).Exists())
            {
                Alter.Table(nameof(RasteBazar))
                    .AddColumn(nameof(RasteBazar.CreatedOnUtc)).AsDateTime2().Nullable();
            }

            //add column UpdatedOnUtc
            if (!Schema.Table(nameof(RasteBazar)).Column(nameof(RasteBazar.UpdatedOnUtc)).Exists())
            {
                Alter.Table(nameof(RasteBazar))
                    .AddColumn(nameof(RasteBazar.UpdatedOnUtc)).AsDateTime2().Nullable();
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
