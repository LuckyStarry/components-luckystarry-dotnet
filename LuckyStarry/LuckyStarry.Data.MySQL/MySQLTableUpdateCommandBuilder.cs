using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilder : MySQLTableBuilder, ITableBuilderUpdatable
    {
        private readonly MySQLTableUpdateCommandBuilder setted;
        private readonly MySQLUpdateBuilder update;
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLTableUpdateCommandBuilder(MySQLUpdateBuilder update, Data.Objects.IDbTable table) : base(update, table)
        {
            this.update = update;
            this.table = table;
        }

        protected internal MySQLTableUpdateCommandBuilder(MySQLTableUpdateCommandBuilder setted) : this(setted.update, setted.table) => this.setted = setted;

        ITableBuilderUpdatable ITableBuilderUpdatable.Set(Data.Objects.IDbColumn column, Data.Objects.IDbParameter paramter) => this.Set(column, paramter);

        public virtual MySQLTableUpdateCommandBuilderUpdatedColumnsSetted Set(Data.Objects.IDbColumn column, Data.Objects.IDbParameter paramter) => new MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(this, column, paramter);

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
