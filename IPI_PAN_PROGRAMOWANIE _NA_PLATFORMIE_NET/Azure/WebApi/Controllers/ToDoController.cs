using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        DatabaseContext _dbContext;

        public ToDoController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values/5
        [HttpGet("{ownerId}")]
        public ActionResult<IEnumerable<ToDoItemDTO>> Get(string ownerId)
        {
            IQueryable<ToDoItemDTO> toDoItems = _dbContext.ToDoItems.Where(item => item.OwnerId == ownerId && !item.IsDone).Select(item => new ToDoItemDTO() {
                Id = item.Id,
                IsDone = item.IsDone,
                Title = item.Title,
                DueAt = item.DueAt
            });
                       
            return toDoItems.ToList();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] ToDoItemDTO value)
        {
            Guid id = Guid.NewGuid();
            _dbContext.ToDoItems.Add(new Database.Entities.ToDoItem()
            {
                Id = id,
                IsDone = value.IsDone,
                Title = value.Title,
                DueAt = value.DueAt,
                OwnerId = value.OwnerId
            });

            _dbContext.SaveChanges();

            return id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ToDoItemDTO value)
        {
            Database.Entities.ToDoItem dbItem =  _dbContext.ToDoItems.SingleOrDefault(item => item.Id == id);
            dbItem.IsDone = value.IsDone;
            _dbContext.SaveChanges();
        }

     
    }
}
