using AuthDatabase.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class TodoItemService:ITodoItemService
    {
        string url = "https://localhost:44373/";
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;

        public TodoItemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Guid> AddItemAsync(TodoItemViewModel newItem, AppUser user)
        {
            TodoServiceHttpClient todoServiceClient = new TodoServiceHttpClient(url, httpClient);

            newItem.OwnerId = user.Id;
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            Guid returnValue = await todoServiceClient.PostAsync(_mapper.Map<ToDoItemDTO>(newItem));
         
            return returnValue;          
        }

        public async Task<TodoItemViewModel[]> GetIncompleteItemsAsync(AppUser user)
        {
            TodoServiceHttpClient todoServiceClient = new TodoServiceHttpClient(url, httpClient);
            ICollection<ToDoItemDTO> dtoItems = await todoServiceClient.GetAsync(user.Id);

            ICollection<TodoItemViewModel> returnValue = _mapper.Map<ICollection<TodoItemViewModel>>(dtoItems);

            return returnValue.ToArray();
        }

        public async Task<bool> MarkDoneAsync(TodoItemViewModel item, AppUser user)
        {
            TodoServiceHttpClient todoServiceClient = new TodoServiceHttpClient(url, httpClient);

            item.OwnerId = user.Id;
            item.IsDone = true;

            await todoServiceClient.PutAsync(item.Id, _mapper.Map<ToDoItemDTO>(item));
            return true;

        }
    }
}
