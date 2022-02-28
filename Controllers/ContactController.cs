using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskWebApi.Models;
using TestTaskWebApi.Services;

namespace TestTaskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public Task<Contact> Get([FromRoute]int id) => _contactService.GetById(id);
        
        [HttpGet]
        public Task<List<Contact>> GetAll() => _contactService.GetAll();

        [HttpPost]
        public async Task Add([FromBody]Contact contact) => await _contactService.Add(contact);

        [HttpPut]
        public async Task<Contact> Update([FromBody] Contact contact) => await _contactService.Update(contact);

        [HttpDelete("{id}")]
        public Task Delete([FromRoute]int id) => _contactService.Delete(id);
        
    }
}
