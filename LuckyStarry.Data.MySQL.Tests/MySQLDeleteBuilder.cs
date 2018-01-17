using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLDeleteBuilder
    {
        [Fact]
        public void DeleteTableTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var builder = factory.CreateDeleteBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"DELETE `{ table }`", builder.Build());
        }

        [Fact]
        public void DeleteTableWhereTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var builder = factory.CreateDeleteBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1);

            Assert.Equal($"DELETE `{ table }` WHERE `{ column_1 }` = @{ column_1 }", builder.Build());
        }

        [Fact]
        public void UpdateTableSetWhereTwoConditionsTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var builder = factory.CreateDeleteBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1.And(condition_2));

            Assert.Equal($"DELETE `{ table }` WHERE (`{ column_1 }` = @{ column_1 }) AND (`{ column_2 }` = @{ column_2 })", builder.Build());
        }

        [Fact]
        public void UpdateTableSetWhereTreeTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var builder = factory.CreateDeleteBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1)
                .And(condition_2.Not());

            Assert.Equal($"DELETE `{ table }` WHERE `{ column_1 }` = @{ column_1 } AND NOT (`{ column_2 }` = @{ column_2 })", builder.Build());
        }
    }
}
