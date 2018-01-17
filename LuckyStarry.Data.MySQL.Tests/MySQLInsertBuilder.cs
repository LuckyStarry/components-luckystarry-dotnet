using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLInsertBuilder
    {
        [Fact]
        public void InsertTableOneColumnTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column = Utils.RandomName();
            var builder = factory.CreateInsertBuilder()
                .Into(factory.GetDbObjectFactory().CreateTable(table))
                .Column(factory.GetDbObjectFactory().CreateColumn(column))
                .Value(factory.GetDbObjectFactory().CreateParameter(column));

            Assert.Equal($"INSERT INTO `{ table }` ( `{ column }` ) VALUES ( @{ column } )", builder.Build());
        }

        [Fact]
        public void InsertTableTwoColumnTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var builder = factory.CreateInsertBuilder()
                .Into(factory.GetDbObjectFactory().CreateTable(table))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .Value(factory.GetDbObjectFactory().CreateParameter(column_1))
                .Value(factory.GetDbObjectFactory().CreateParameter(column_2));

            Assert.Equal($"INSERT INTO `{ table }` ( `{ column_1 }`, `{ column_2 }` ) VALUES ( @{ column_1 }, @{ column_2 } )", builder.Build());
        }

        [Fact]
        public void InsertTableThreeColumnTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var builder = factory.CreateInsertBuilder()
                .Into(factory.GetDbObjectFactory().CreateTable(table))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_1))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_2))
                .Column(factory.GetDbObjectFactory().CreateColumn(column_3))
                .Value(factory.GetDbObjectFactory().CreateParameter(column_1))
                .Value(factory.GetDbObjectFactory().CreateParameter(column_2))
                .Value(factory.GetDbObjectFactory().CreateParameter(column_3));

            Assert.Equal($"INSERT INTO `{ table }` ( `{ column_1 }`, `{ column_2 }`, `{ column_3 }` ) VALUES ( @{ column_1 }, @{ column_2 }, @{ column_3 } )", builder.Build());
        }

        [Fact]
        public void InsertTableColumnListTest()
        {
            var factory = new MySQLCommandFactory();
            var table = Utils.RandomName();
            var column_1 = Utils.RandomName();
            var column_2 = Utils.RandomName();
            var column_3 = Utils.RandomName();
            var columns = new[] { column_1, column_2, column_3 };
            var builder = factory.CreateInsertBuilder()
                .Into(factory.GetDbObjectFactory().CreateTable(table))
                .Columns(columns.Select(column => factory.GetDbObjectFactory().CreateColumn(column)))
                .Values(columns.Select(column => factory.GetDbObjectFactory().CreateParameter(column)));

            Assert.Equal($"INSERT INTO `{ table }` ( `{ column_1 }`, `{ column_2 }`, `{ column_3 }` ) VALUES ( @{ column_1 }, @{ column_2 }, @{ column_3 } )", builder.Build());
        }
    }
}
