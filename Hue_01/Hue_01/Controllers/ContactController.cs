using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hue_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private static readonly List<Contact> contacts=new List<Contact>();

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/Contacts")]
        public IActionResult Get()
        {
            return Ok(contacts);
        }
        [HttpGet]
        [Route("/Contacts/findByName")]
        public IActionResult GetByName([FromQuery][Required()] string nameFilter)
        {
            List<Contact> toSend = new List<Contact>();
            for(var i=0;i<contacts.Count();i++)
            {
                if (contacts[i].firstname.Contains(nameFilter)|| contacts[i].lastName.Contains(nameFilter))
                {
                    toSend.Add(contacts[i]);
                }
            }
            return Ok(toSend);
        }
    }
}
