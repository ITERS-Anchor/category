using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Model;
using Test.BLL;
using System.Web.Routing;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService service = new CategoryService();
        // GET: Category
        public ActionResult Delete(int id)
        {
            int result = service.Delete(id);
            if (result>0)
            {
                return Redirect(@Url.Action("ShowAllCategories", "Category"));
            }
            return Redirect(@Url.Action("Index", "Category"));
        }
        [HttpPost]
        public ActionResult Add(string name,int pid)
        {
            Category c = new Category { CateName = name, ParentId = pid };
            int result = service.Create(c);
            if (result >0)
            {
                //return Redirect(@Url.Action("ShowAllCategories", "Category"));
                //ViewBag.msg = "Add Failed!";
                //ViewBag.Msg = "Wrong name or password!";
            }
            //return JavaScript("alert('error!')");
            return Redirect(@Url.Action("ShowAllCategories", "Category"));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData.Model = service.GetById(id);
            //Category entity = service.GetById(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            if (service.Edit(c)>0)
            {
                TempData["status"] = "Edit Successful!";
                return RedirectToAction("ShowAllCategories");
                //return Redirect(@Url.Action("ShowAllCategories", "Category"));
            }
            else
            {
                return Redirect(@Url.Action("Edit", new RouteValueDictionary(new
                {
                    id = c.Id
                })));
            }
        }
      
        public ActionResult ShowAllCategories()
        {
            IQueryable<Category> cateList= service.LoadAllCategories();
            return View(cateList);
        }
    }
}