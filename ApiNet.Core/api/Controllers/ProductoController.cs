using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace api.Controllers
{
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService studentService)
        {
            _productoService = studentService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _productoService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                   _productoService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Producto model)
        {
            return Ok(
                   _productoService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Producto model)
        {
            return Ok(
                   _productoService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                   _productoService.Delete(id)
            );
        }
    }
}
