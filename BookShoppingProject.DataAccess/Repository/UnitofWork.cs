using BookShoppingProject.DataAccess.Data;
using BookShoppingProject.DataAccess.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _Context;

        public UnitofWork(ApplicationDbContext Context)
        {
            _Context = Context;
            category = new CategoryRepository(_Context);
            coverType = new CoverTypeRepository(_Context);
        }
        public ICategoryRepository  category{get; private set;}
        public  ICoverTypeRepository coverType{ get; private set; }

        public void save()
        {
            _Context.SaveChanges();
        }
}


}
