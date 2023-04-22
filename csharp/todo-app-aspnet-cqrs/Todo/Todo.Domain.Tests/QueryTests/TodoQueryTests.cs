using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now),
                new TodoItem("Tarefa 2", "UsuarioA", DateTime.Now),
                new TodoItem("Tarefa 3", "moya", DateTime.Now),
                new TodoItem("Tarefa 4", "UsuarioA", DateTime.Now),
                new TodoItem("Tarefa 5", "moya", DateTime.Now)
            };

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_moya()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("moya"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
