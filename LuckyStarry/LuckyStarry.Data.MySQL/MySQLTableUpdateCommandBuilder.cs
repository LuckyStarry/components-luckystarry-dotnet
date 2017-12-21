using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilder : MySQLTableBuilder, ITableBuilderUpdatable
    {
        private readonly MySQLTableUpdateCommandBuilder setted;
        private readonly MySQLUpdateBuilder update;
        private readonly string table;

        public MySQLTableUpdateCommandBuilder(MySQLUpdateBuilder update, string table) : base(update, table)
        {
            this.update = update;
            this.table = table;
        }

        internal MySQLTableUpdateCommandBuilder(MySQLTableUpdateCommandBuilder setted) : this(setted.update, setted.table) => this.setted = setted;

        ITableBuilderUpdatable ITableBuilderUpdatable.Set(string column, string paramter) => this.Set(column, paramter);

        public virtual MySQLTableUpdateCommandBuilderUpdatedColumnsSetted Set(string column, string paramter) => new MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(this, column, paramter);

        public override string Build()
        {
            if (this is MySQLTableUpdateCommandBuilderUpdatedColumnsSetted)
            {
                return base.Build();
            }
            else
            {
                throw new MySQLNoneSetException();
            }
        }
    }
}
