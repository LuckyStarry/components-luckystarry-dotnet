using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilderUpdatedColumnsSetted : MySQLTableUpdateCommandBuilder
    {
        private readonly MySQLTableUpdateCommandBuilder table;
        private readonly string column;
        private readonly string paramter;

        public MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(MySQLTableUpdateCommandBuilder table, string column, string paramter) : base(table)
        {
            this.table = table;
            this.column = column;
            this.paramter = paramter;
        }

        protected internal override string CompilePart() => $"`{ this.column }` = @{ this.paramter }";

        protected internal override string Compile()
        {
            return $"{ this.table.Compile() } { (this.table is MySQLTableUpdateCommandBuilderUpdatedColumnsSetted ? "SET" : ",") } { this.CompilePart() }";
        }
    }
}
