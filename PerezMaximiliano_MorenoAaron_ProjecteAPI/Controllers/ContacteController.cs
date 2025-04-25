using Data;
using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using Entitats.RestaurantClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContacteController : ControllerBase
    {
        private readonly DBContext _context;

        public ContacteController(DBContext context)
        {
            _context = context;
        }

        [HttpPost("EnviarMissatge")]
        public async Task<IActionResult> EnviarMissatge([FromBody] MissatgesUsuari missatge)
        {
            try
            {
                _context.MissatgesUsuaris.Add(missatge);
                await _context.SaveChangesAsync();
                return Ok("Message sent");
            }
            catch (Exception ex)
            {
                return BadRequest(); 
            }
        }
    }
}
