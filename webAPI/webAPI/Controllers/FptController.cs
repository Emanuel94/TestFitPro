using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Controllers.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FptController : ControllerBase
    {
        private readonly FptRepository fptRepository;


        public FptController()
        {
            fptRepository = new FptRepository();
        }
        [HttpGet]
        public IEnumerable<Fpt> Get()
        {
            return fptRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Fpt Get(int id)
        {
            return fptRepository.GetById(id);

        }
        [HttpPost]
        public void Post([FromBody] Fpt fpt)
        {
            if (ModelState.IsValid)
                fptRepository.Add(fpt);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            fptRepository.Delete(id);
        }


    }
}
