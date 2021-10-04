using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Models;

 namespace LinkShortener.Controllers
 {
    [Route("api/[controller]")]
    [ApiController]
    class ShortLinkContoller: ControllerBase
    {
        private readonly IRepository<IEntity> repository;
         private readonly LinkService linkService;
        public ShortLinkContoller(IRepository<IEntity> repository, LinkService linkService)
        {
            this.repository = repository;
            this.linkService = linkService;
        }
        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/"link.com"
        [HttpGet("{Link}")]
        public async Task<ActionResult<IEntity>> Get(string link)
        {
            var linkEntity = await repository.Get(link);
            if (linkEntity == null)
            {
                return NotFound();
            }
            return new JsonResult(linkEntity);
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IEntity linkEntity)
        {
           
            if (id != linkEntity.Id)
            {
                return BadRequest();
            }
            await repository.Update(linkEntity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<IEntity>> Post(string link)
        {
            if (repository.IsFind(link).Result == false)
            {
                var Entity = linkService.CreateEntity(link);
                await repository.Add(Entity);
                return CreatedAtAction("Get", new {key = Entity.Id}, Entity);
            }
            else
            {
                var Entity = repository.Get(link);
                return CreatedAtAction("Get", new {key = Entity.Id}, Entity);
            }
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> Delete(int id)
        {
            var linkEntity = await repository.Delete(id);
            if (linkEntity == null)
            {
                return NotFound();
            }
            return new AcceptedResult();
        }
    }
 }