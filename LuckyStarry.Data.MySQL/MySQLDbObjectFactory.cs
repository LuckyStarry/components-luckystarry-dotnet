﻿using System;
using System.Collections.Generic;
using System.Text;
using LuckyStarry.Data.Objects;

namespace LuckyStarry.Data.MySQL
{
    public class MySQLDbObjectFactory : IDbObjectFactory
    {
        protected internal MySQLDbObjectFactory() { }

        IDbColumn IDbObjectFactory.CreateColumn(string name) => this.CreateColumn(name);
        IDbParameter IDbObjectFactory.CreateParameter(string name) => this.CreateParameter(name);
        IDbTable IDbObjectFactory.CreateTable(string name) => this.CreateTable(name);

        public virtual Objects.MySQLColumn CreateColumn(string name) => new Objects.MySQLColumn(name);
        public virtual Objects.MySQLParameter CreateParameter(string name) => new Objects.MySQLParameter(name);
        public virtual Objects.MySQLTable CreateTable(string name) => new Objects.MySQLTable(name);

        public virtual Objects.MySQLColumn CreateColumn(string name, string alias) => new Objects.MySQLColumn(name, alias);
        public virtual Objects.MySQLTable CreateTable(string name, string alias) => new Objects.MySQLTable(name, alias);
    }
}
