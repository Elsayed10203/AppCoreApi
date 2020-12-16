using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbcontextRepo db;
        private ILoggerManager Log;

        public ProductController(DbcontextRepo Context, ILoggerManager Ilogger)
        {
            db = Context;
            Log = Ilogger;
        
        }
        /* public IActionResult GetAll()
         {
             return Ok(db.Product);
         }*/
        [HttpPut]
        public IActionResult AddProduct(Product Prod)
        {
            if (Prod != null)
            {
                db.Product.Add(Prod);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteProdut(int? id)
        {
            if (id != null)
            {

                db.Product.Remove(db.Product.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int ?id)
        {
            if(id!=null)
            {
                Log.LogInfo($"logger info {id}");
                return Ok(db.Product.FirstOrDefault(x => x.Id == id));
            }
            Log.LogError($"the id is Not Found here {id}");
            return Content("The id is not Valid ");
        }
        
    }
}