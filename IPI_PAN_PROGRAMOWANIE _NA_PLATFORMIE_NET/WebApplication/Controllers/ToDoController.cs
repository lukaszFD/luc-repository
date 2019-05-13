using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace ToDoApp.MVC.Controllers
{

    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<AppUser> _userManager;
         
        public TodoController(
            ITodoItemService todoItemService,
            UserManager<AppUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            TodoItemViewModel[] currentTodoItems = await _todoItemService.GetIncompleteItemsAsync(currentUser);

            var model = new TodoViewModel()
            {
                Items = currentTodoItems
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItemViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Index");
            }

            Guid successfulGuid = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (successfulGuid == null || successfulGuid == Guid.Empty)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Index");
            }

            TodoItemViewModel[] currentTodoItems = await _todoItemService.GetIncompleteItemsAsync(currentUser);
            TodoItemViewModel item = currentTodoItems.SingleOrDefault(i => i.Id == id);

            var successful = await _todoItemService.MarkDoneAsync(item, currentUser);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }
    }

}