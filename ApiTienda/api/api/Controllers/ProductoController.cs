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

        public ProductoController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _studentService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int codigo)
        {
            return Ok(
                _studentService.Get(codigo)
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Producto model)
        {
            return Ok(
                _studentService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Producto model)
        {
            return Ok(
                _studentService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int codigo)
        {
            return Ok(
                _studentService.Delete(codigo)
            );
        }
    }
}
