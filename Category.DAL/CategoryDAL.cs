using Test.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL
{
    public  class CategoryDAL
    {
        DbContext dbContext = new CategoryDbContext();
        //CRUD
        //1.Create new Category
        public int Create(Category c)
        {           
            dbContext.Set<Category>().Add(c);
            return dbContext.SaveChanges();                
        }
        //2.Delete
        public int Delete(int id)
        {
            var c = GetById(id);
            //var c = dbContext.Set<Category>().Where(x=>x.Id==id);
            dbContext.Set<Category>().Remove(c);
            return dbContext.SaveChanges();
        }
        //3.Edit
        public int Edit(Category c)
        {
            dbContext.Set<Category>().Attach(c);
            dbContext.Entry(c).State = System.Data.EntityState.Modified;
            //db.Users.Attach(updatedUser);
            //var entry = db.Entry(updatedUser);
            //entry.Property(e => e.Email).IsModified = true;
            //// other changed properties
            //db.SaveChanges();
            return dbContext.SaveChanges();
        }
        public Category GetById(int id)
        {
            return dbContext.Set<Category>().Where(x => x.Id == id).FirstOrDefault();
        }

        //4.Load All Categories
        public IQueryable<Category> LoadAllCategories()
        {
            return dbContext.Set<Category>().OrderBy(x => x.ParentId);
        }
    }
}
