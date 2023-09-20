using Nop.Core.Domain.RasteBazars;
using Nop.Data.Mapping.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.RasteBazar.Domains;
using FluentMigrator.Builders.Create.Table;

namespace Nop.Plugin.RasteBazar.Mapping
{
    /// <summary>
    /// Represents a check entity builder
    /// </summary>
    public class CheckBuilder : NopEntityBuilder<Check>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(Check.Id)).AsInt32().PrimaryKey().
                WithColumn(nameof(Check.OwnerName)).AsString(250).NotNullable().
                WithColumn(nameof(Check.Amount)).AsDecimal().NotNullable();
        }
    }
}
