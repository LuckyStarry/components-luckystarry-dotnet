using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.Services
{
    abstract class DbColumns
    {
        private readonly static IDictionary<Type, IEnumerable<Data.Objects.IDbColumn>> columns = new Dictionary<Type, IEnumerable<Data.Objects.IDbColumn>>();
        public static IEnumerable<Data.Objects.IDbColumn> GetColumns<TEntity>(Data.IDbObjectFactory factory)
        {
            var type = typeof(TEntity);
            if (columns.ContainsKey(type))
            {
                return columns[type];
            }
            else
            {
                var cc = typeof(TEntity).GetProperties().Select(p => factory.CreateColumn(p.Name)).ToArray();
                columns[type] = cc;
                return cc;
            }
        }
    }
}
