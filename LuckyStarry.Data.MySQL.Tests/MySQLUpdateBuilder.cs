using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLUpdateBuilder
    {
        [Fact]
        public void UpdateTableTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Throws(typeof(MySQLNoneSetException), builder.Build);
        }

        [Fact]
        public void UpdateTableSetOneColumnTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table))
                .Set(factory.GetDbObjectFactory().CreateColumn(column), factory.GetDbObjectFactory().CreateParameter(column));

            Assert.Equal($"UPDATE `{ table }` SET `{ column }` = @{ column }", builder.Build());
        }

        [Fact]
        public void UpdateTableSetTwoColumnsTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));

            Assert.Equal($"UPDATE `{ table }` SET `{ column_1 }` = @{ column_1 }, `{ column_2 }` = @{ column_2 }", builder.Build());
        }

        [Fact]
        public void UpdateTableSetWhereTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2))
                .Where(condition_3);

            Assert.Equal($"UPDATE `{ table }` SET `{ column_1 }` = @{ column_1 }, `{ column_2 }` = @{ column_2 } WHERE `{ column_3 }` = @{ column_3 }", builder.Build());
        }

        [Fact]
        public void UpdateTableSetWhereTwoConditionsTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var column_4 = Utils.RandomName();
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var condition_4 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_4), factory.GetDbObjectFactory().CreateParameter(column_4));
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2))
                .Where(condition_3.Or(condition_4));

            Assert.Equal($"UPDATE `{ table }` SET `{ column_1 }` = @{ column_1 }, `{ column_2 }` = @{ column_2 } WHERE (`{ column_3 }` = @{ column_3 }) OR (`{ column_4 }` = @{ column_4 })", builder.Build());
        }

        [Fact]
        public void UpdateTableSetWhereTreeTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var column_4 = Utils.RandomName();
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var condition_4 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_4), factory.GetDbObjectFactory().CreateParameter(column_4));
            var builder = factory.CreateUpdateBuilder()
                .Table(factory.GetDbObjectFactory().CreateTable(table))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1))
                .Set(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2))
                .Where(condition_3)
                .Or(condition_4.Not());

            Assert.Equal($"UPDATE `{ table }` SET `{ column_1 }` = @{ column_1 }, `{ column_2 }` = @{ column_2 } WHERE `{ column_3 }` = @{ column_3 } OR NOT (`{ column_4 }` = @{ column_4 })", builder.Build());
        }
    }
}
