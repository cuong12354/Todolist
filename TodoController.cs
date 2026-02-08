using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using System.Collections.Generic;
using System;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> todos = new List<Todo>
        {
            new Todo { Id = 1, TenCongViec = "Đi chợ", TrangThai = false, NgayTao = DateTime.Now },
            new Todo { Id = 2, TenCongViec = "Chơi thể thao", TrangThai = false, NgayTao = DateTime.Now },
            new Todo { Id = 3, TenCongViec = "Chơi game", TrangThai = false, NgayTao = DateTime.Now },
            new Todo { Id = 4, TenCongViec = "Học bài", TrangThai = false, NgayTao = DateTime.Now }
        };

        public IActionResult Index()
        {
            return View(todos);
        }

        public IActionResult Details(int id)
        {
            var todo = todos.Find(t => t.Id == id);
            return View(todo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            todo.Id = todos.Count + 1;
            todo.NgayTao = DateTime.Now;
            todos.Add(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var todo = todos.Find(t => t.Id == id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            var old = todos.Find(t => t.Id == todo.Id);
            old.TenCongViec = todo.TenCongViec;
            old.TrangThai = todo.TrangThai;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var todo = todos.Find(t => t.Id == id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            todos.RemoveAll(t => t.Id == id);
            return RedirectToAction("Index");
        }
    }
}
