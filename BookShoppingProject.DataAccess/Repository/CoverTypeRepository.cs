﻿using BookShoppingProject.DataAccess.Data;
using BookShoppingProject.DataAccess.Repository.iRepository;
using BookShoppingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject.DataAccess.Repository
{
    class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _Context;

        public CoverTypeRepository(ApplicationDbContext Context):base(Context)
        {
            _Context = Context;

        }
        public void Update(CoverType coverType)
        {
            _Context.Update(coverType);
        }
    }
}
