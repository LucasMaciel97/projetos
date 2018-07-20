using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_webap_bd.Models;

namespace test_webap_bd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Context _context;

        public ProdutoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            //ProdutosList prod = _context.Produtos.ToList();
            var result = from r in _context.Produto select r;

            return _context.Produto.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Produto> GetById(int id)
        {
            var item = _context.Produto.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Produto item)
        {
            _context.Produto.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Produto item)
        {
            var todo = _context.Produto.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.iscomplete = item.iscomplete;
            todo.nome = item.nome;

            _context.Produto.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Produto.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }


    }
}