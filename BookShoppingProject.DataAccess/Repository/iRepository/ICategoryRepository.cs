using BookShoppingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject.DataAccess.Repository.iRepository
{
   public interface ICategoryRepository:iRepository<Category>
    {
        void Update(Category category);
    }
}
