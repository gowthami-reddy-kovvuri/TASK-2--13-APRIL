using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_2__13_APRIL.Models;
namespace TASK_2__13_APRIL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Productdet> Get()
        {
            DB3Context pnt = new DB3Context();
            return pnt.Productdet;
        }

        // GET api/<ProductController>/5
        [HttpGet("{pcode}")]
        public IEnumerable<Productdet> Get(int pcode)
        {
            DB3Context pnt = new DB3Context();
            var sql = from i in pnt.Productdet where i.Pcode == pcode select i;
            return sql;
        }
        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Productdet value)
        {
            DB3Context pnt = new DB3Context();
            pnt.Productdet.Add(value);
            pnt.SaveChanges();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Productdet value)
        {
            DB3Context pnt = new DB3Context();
            var det = pnt.Productdet.Find(id);
            if (det != null)
            {
                det.Pname = value.Pname;
                det.Pdesc = value.Pdesc;
                det.Unitprice = value.Unitprice;
                det.Category = value.Category;
                det.Stockinhand = value.Stockinhand;
                pnt.SaveChanges();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DB3Context pnt = new DB3Context();
            var del = pnt.Productdet.Find(id);
            pnt.Productdet.Remove(del);
            pnt.SaveChanges();
        }
    }
}



