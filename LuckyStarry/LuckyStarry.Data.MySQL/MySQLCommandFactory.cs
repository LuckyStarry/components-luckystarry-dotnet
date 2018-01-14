using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLCommandFactory : ICommandFactory
    {
        ISelectBuilder ICommandFactory.CreateSelectBuilder() => this.CreateSelectBuilder();
        IUpdateBuilder ICommandFactory.CreateUpdateBuilder() => this.CreateUpdateBuilder();
        IInsertBuilder ICommandFactory.CreateInsertBuilder() => this.CreateInsertBuilder();
        IDeleteBuilder ICommandFactory.CreateDeleteBuilder() => this.CreateDeleteBuilder();
        IConditionFactory ICommandFactory.GetConditionFactory() => this.GetConditionFactory();
        IDbObjectFactory ICommandFactory.GetDbObjectFactory() => this.GetDbObjectFactory();

        public virtual MySQLSelectBuilder CreateSelectBuilder() => new MySQLSelectBuilder(this);
        public virtual MySQLInsertBuilder CreateInsertBuilder() => new MySQLInsertBuilder(this);
        public virtual MySQLUpdateBuilder CreateUpdateBuilder() => new MySQLUpdateBuilder(this);
        public virtual MySQLDeleteBuilder CreateDeleteBuilder() => new MySQLDeleteBuilder(this);
        public virtual MySQLConditionFactory GetConditionFactory() => new MySQLConditionFactory(this);
        public virtual MySQLDbObjectFactory GetDbObjectFactory() => new MySQLDbObjectFactory();
    }
}
