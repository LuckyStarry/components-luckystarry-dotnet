using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilderUpdatedColumnsSetted : MySQLTableUpdateCommandBuilder
    {
        private readonly Data.Objects.IDbColumn column;
        private readonly Data.Objects.IDbParameter parameter;

        protected internal MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(MySQLTableUpdateCommandBuilder table, Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) : base(table)
        {
            this.column = column;
            this.parameter = parameter;
        }

        protected internal override string CompilePart() => $"{ this.column.SqlText } = { this.parameter.SqlText }";

        protected internal override string Compile()
        {
            var connect = this.Previous is MySQLTableUpdateCommandBuilderUpdatedColumnsSetted ? ", " : " SET ";
            return $"{ this.Previous.Compile() }{ connect }{ this.CompilePart() }";
        }
    }
}
