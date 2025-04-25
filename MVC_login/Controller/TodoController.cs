using System.Collections.Generic;
using System.Web.Mvc;
using TodoMvcLogin.Models;

namespace TodoMvcLogin.Controllers 
{
    public class TodoController : Controllers
    {
        private static List<TodoItem> tarefas = new List<TodoItem>();

        public ActionResult Index()
        {
            return View(tarefas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoItem item)
        {
            item.Id = tarefas.Count + 1;
            tarefas.Add(item);
            return RedirecToAction("Index");
        }
    }
}