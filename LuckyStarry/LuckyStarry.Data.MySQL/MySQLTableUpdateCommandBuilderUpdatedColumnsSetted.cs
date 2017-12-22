using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilderUpdatedColumnsSetted : MySQLTableUpdateCommandBuilder
    {
        private readonly MySQLTableUpdateCommandBuilder table;
        private readonly Data.Objects.IDbColumn column;
        private readonly Data.Objects.IDbParameter parameter;

        protected internal MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(MySQLTableUpdateCommandBuilder table, Data.Objects.IDbColumn column, Data.Objects.IDbParameter parameter) : base(table)
        {
            this.table = table;
            this.column = column;
            this.parameter = parameter;
        }

        protected internal override string CompilePart() => $"{ this.column.SqlText } = { this.parameter.SqlText }";

        protected internal override string Compile()
        {
            return $"{ this.table.Compile() } { (this.table is MySQLTableUpdateCommandBuilderUpdatedColumnsSetted ? "SET" : ",") } { this.CompilePart() }";
        }
    }
}
