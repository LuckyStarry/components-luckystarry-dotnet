using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLSelectBuilder
    {
        [Fact]
        public void SelectStarFromTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT * FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumnFromTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .Column(factory.GetDbObjectFactory().CreateColumn(column))
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT `{ column }` FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumn2FromTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT `{ column_1 }`, `{ column_2 }` FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumn3FromTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_3))
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT `{ column_1 }`, `{ column_2 }`, `{ column_3 }` FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumnsTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var columns = new[] { column_1, column_2, column_3 };
            var builder = factory.CreateSelectBuilder()
                .Columns(columns.Select(column => factory.GetDbObjectFactory().CreateColumn(column)))
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT `{ column_1 }`, `{ column_2 }`, `{ column_3 }` FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumnAliasFromTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var alias_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1, alias_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .From(factory.GetDbObjectFactory().CreateTable(table));

            Assert.Equal($"SELECT `{ column_1 }` AS `{ alias_1 }`, `{ column_2 }` FROM `{ table }`", builder.Build());
        }

        [Fact]
        public void SelectColumnFromAliasTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var alias_1 = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .From(factory.GetDbObjectFactory().CreateTable(table, alias_1));

            Assert.Equal($"SELECT `{ column_1 }`, `{ column_2 }` FROM `{ table }` AS `{ alias_1 }`", builder.Build());
        }
    }
}
