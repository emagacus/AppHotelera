using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using static Java.Util.Jar.Attributes;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ServicioController : ApiController
    {
        public ServicioController(ServicioRepo todoItems)
        {
            TodoItems = todoItems;
        }
        public ServicioRepo TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<Servicio> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }



    }
}
