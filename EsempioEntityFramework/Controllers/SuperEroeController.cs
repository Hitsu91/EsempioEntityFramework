using EsempioEntityFramework.Models;
using EsempioEntityFramework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsempioEntityFramework.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperEroeController : ControllerBase
    {
        private readonly ISuperEroeService _service;

        // DI del nostro service
        public SuperEroeController(ISuperEroeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<SuperEroe> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public SuperEroe Add([FromBody] SuperEroe newSuperEroe)
        {
            return _service.AddNew(newSuperEroe);
        }

        [HttpGet("{id}")]
        public SuperEroe GetById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public SuperEroe DeleteById([FromRoute] int id)
        {
            return _service.DeleteById(id);
        }
    }
}
