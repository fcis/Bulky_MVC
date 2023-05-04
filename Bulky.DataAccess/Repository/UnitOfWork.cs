﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
         private ApplicationDbContext _Db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext DB)
        {
            _Db= DB;
            Category = new CategoryRepository(_Db);
            Product = new ProductRepository(_Db);

        }

        public void Save()
        {
            _Db.SaveChanges();
        }
    }
}