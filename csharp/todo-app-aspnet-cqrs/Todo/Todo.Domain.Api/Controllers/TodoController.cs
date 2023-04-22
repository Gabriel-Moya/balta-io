using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetAll("gabrielmoya");
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody]CreateTodoCommand command,
            [FromServices]TodoHandler handler)
        {
            command.User = "gabrielmoya";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
