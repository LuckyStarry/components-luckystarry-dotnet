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
        public void SelectStarFromWhereAndTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .Where(factory.GetConditionFactory().EqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column_1),
                    factory.GetDbObjectFactory().CreateParameter(column_1)))
                .And(factory.GetConditionFactory().EqualTo(
                    factory.GetDbObjectFactory().CreateColumn(column_2),
                    factory.GetDbObjectFactory().CreateParameter(column_2)));

            Assert.Equal($"SELECT * FROM `{ table }` WHERE `{ column_1 }` = @{ column_1 } AND `{ column_2 }` = @{ column_2 }", builder.Build());
        }
    }
}
