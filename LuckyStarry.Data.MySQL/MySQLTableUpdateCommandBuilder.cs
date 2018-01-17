using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLTableUpdateCommandBuilder : MySQLTableBuilder, ITableBuilderUpdatable
    {
        private readonly Data.Objects.IDbTable table;

        protected internal MySQLTableUpdateCommandBuilder(MySQLCommandFactory factory, MySQLUpdateBuilder update, Data.Objects.IDbTable table) : base(factory, update, table) => this.table = table;
        protected internal MySQLTableUpdateCommandBuilder(MySQLCommandFactory factory, MySQLTableUpdateCommandBuilder setted) : base(factory, setted) { }

        ITableBuilderUpdatable ITableBuilderUpdatable.Set(Data.Objects.IDbColumn column, Data.Objects.IDbParameter paramter) => this.Set(column, paramter);

        public virtual MySQLTableUpdateCommandBuilderUpdatedColumnsSetted Set(Data.Objects.IDbColumn column, Data.Objects.IDbParameter paramter) => new MySQLTableUpdateCommandBuilderUpdatedColumnsSetted(this.factory, this, column, paramter);

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
