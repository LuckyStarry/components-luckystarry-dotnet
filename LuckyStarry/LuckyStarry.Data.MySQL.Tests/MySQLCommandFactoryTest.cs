using System;
using Xunit;

namespace LuckyStarry.Data.MySQL.Tests
{
    public class MySQLCommandFactoryTest
    {
        [Fact]
        public void CreateTest()
        {
            var factory = new MySQLCommandFactory();
            Assert.IsAssignableFrom<ISelectBuilder>(factory.CreateSelectBuilder());
            Assert.IsAssignableFrom<IInsertBuilder>(factory.CreateInsertBuilder());
            Assert.IsAssignableFrom<IUpdateBuilder>(factory.CreateUpdateBuilder());
            Assert.IsAssignableFrom<IDeleteBuilder>(factory.CreateDeleteBuilder());
        }
    }
}
