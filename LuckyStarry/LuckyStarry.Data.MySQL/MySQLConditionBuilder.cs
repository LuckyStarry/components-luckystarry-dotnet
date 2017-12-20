using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLConditionBuilder : MySQLBuilder, ISqlConditionBuilder
    {
        private ISqlConditionBuilder right;
        private RelationshipType relationship;
        private readonly string column;
        private readonly string paramter;

        public MySQLConditionBuilder(string column, string paramter) : base(null)
        {
            this.column = column;
            this.paramter = paramter;
        }

        protected internal override string CompilePart()
        {
            return this.right == null
                ? $"(`{ this.column }` = @{ this.paramter })"
                : $"(`{ this.column }` = @{ this.paramter } { this.relationship } )";
        }

        ISqlConditionBuilder ISqlConditionBuilder.And(string column, string parameter) => this.And(column, parameter);
        ISqlConditionBuilder ISqlConditionBuilder.And(ISqlConditionBuilder condition) => this.And(condition);
        ISqlConditionBuilder ISqlConditionBuilder.Or(string column, string parameter) => this.Or(column, parameter);
        ISqlConditionBuilder ISqlConditionBuilder.Or(ISqlConditionBuilder condition) => this.Or(condition);
        string ISqlConditionBuilder.Compile() => this.Compile();

        public virtual MySQLConditionBuilder And(string column, string parameter)
        {
            return this.And(new MySQLConditionBuilder(column, parameter));
        }

        public virtual MySQLConditionBuilder And(ISqlConditionBuilder condition)
        {
            this.right = condition;
            this.relationship = RelationshipType.And;
            return this;
        }

        public virtual MySQLConditionBuilder Or(string column, string parameter)
        {
            return this.Or(new MySQLConditionBuilder(column, parameter));
        }

        public virtual MySQLConditionBuilder Or(ISqlConditionBuilder condition)
        {
            this.right = condition;
            this.relationship = RelationshipType.Or;
            return this;
        }

        protected internal override string Compile()
        {
            if (this.Previous == null)
            {
                return base.Compile();
            }

            return $"{ this.Previous?.CompilePart() } { this.relationship } { this.CompilePart() }";
        }

        enum RelationshipType
        {
            And, Or
        }
    }
}
