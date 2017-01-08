using Test.DAL;
using Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BLL
{    
    public  class CategoryService
    {
        CategoryDAL dal = new CategoryDAL();
        //CRUD
        //1.Create new Category
        public int Create(Category c)
        {
            return dal.Create(c);
        }
        //2.Delete
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        //3.Edit
        public int Edit(Category c)
        {
            return dal.Edit(c);
        }
        //4.Load All Categories
        public Category GetById(int id)
        {
            return dal.GetById(id);
        }
        public IQueryable<Category> LoadAllCategories()
        {
            return dal.LoadAllCategories();
        }
    }
}
