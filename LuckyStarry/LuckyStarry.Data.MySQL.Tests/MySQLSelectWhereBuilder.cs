using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLSelectWhereBuilder
    {
        [Fact]
        public void SelectStarFromWhereEQTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().EqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` = @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereNETest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().NotEqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` <> @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereLTTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().LessThan(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` < @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereLTETest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().LessThanOrEqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` <= @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereGTTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().GreaterThan(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` > @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereGTETest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().GreaterThanOrEqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column),
                    factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` >= @{ column }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereNullTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().IsNull(
                    factory.GetDbObjectFactory().CreateColumn(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` IS NULL", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereNotNullTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().NotIsNull(
                    factory.GetDbObjectFactory().CreateColumn(column)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column }` IS NOT NULL", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereAndTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1)
                .And(condition_2);

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column_1 }` = @{ column_1 } AND `{ column_2 }` = @{ column_2 }", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereConditionAndTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1.And(condition_2));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE (`{ column_1 }` = @{ column_1 }) AND (`{ column_2 }` = @{ column_2 })", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereConditionAndTreeTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1.And(condition_2.And(condition_3)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE (`{ column_1 }` = @{ column_1 }) AND ((`{ column_2 }` = @{ column_2 }) AND (`{ column_3 }` = @{ column_3 }))", builder.Build());
        }

        [Fact]
        public void SelectStarFromWhereTreeTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1)
                .And(condition_2.And(condition_3));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column_1 }` = @{ column_1 } AND (`{ column_2 }` = @{ column_2 }) AND (`{ column_3 }` = @{ column_3 })", builder.Build());
        }

        [Fact]
        public void SelectColumnFromLimitTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var offset = new Random().Next(1000, 2000);
            var rows = new Random().Next(10, 20);
            var condition_1 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_1), factory.GetDbObjectFactory().CreateParameter(column_1));
            var condition_2 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_2), factory.GetDbObjectFactory().CreateParameter(column_2));
            var condition_3 = factory.GetConditionFactory().EqualTo(factory.GetDbObjectFactory().CreateColumn(column_3), factory.GetDbObjectFactory().CreateParameter(column_3));
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(condition_1)
                .And(condition_2.And(condition_3))
                .Limit(offset, rows);

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column_1 }` = @{ column_1 } AND (`{ column_2 }` = @{ column_2 }) AND (`{ column_3 }` = @{ column_3 }) LIMIT { offset }, { rows }", builder.Build());
        }
    }
}
