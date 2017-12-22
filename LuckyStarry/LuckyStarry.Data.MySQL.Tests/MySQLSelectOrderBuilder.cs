using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLSelectOrderBuilder
    {
        [Fact]
        public void SelectStarFromOrderByTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .OrderBy(factory.GetDbObjectFactory().CreateColumn(column));

            Assert.Equal($"SELECT * FROM `{ table }` ORDER BY `{ column }`", builder.Build());
        }

        [Fact]
        public void SelectStarFromOrderByThenByTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .OrderByDescending(factory.GetDbObjectFactory().CreateColumn(column_1))
                .ThenBy(factory.GetDbObjectFactory().CreateColumn(column_2));

            Assert.Equal($"SELECT * FROM `{ table }` ORDER BY `{ column_1 }` DESC, `{ column_2 }`", builder.Build());
        }

        [Fact]
        public void SelectStarFromOrderByThenByCompositeTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var builder = factory.CreateSelectBuilder()
                .From(factory.GetDbObjectFactory().CreateTable(table))
                .OrderByDescending(factory.GetDbObjectFactory().CreateColumn(column_1))
                .ThenBy(factory.GetDbObjectFactory().CreateColumn(column_2))
                .ThenByDescending(factory.GetDbObjectFactory().CreateColumn(column_3));

            Assert.Equal($"SELECT * FROM `{ table }` ORDER BY `{ column_1 }` DESC, `{ column_2 }`, `{ column_3 }` DESC", builder.Build());
        }
    }
}
