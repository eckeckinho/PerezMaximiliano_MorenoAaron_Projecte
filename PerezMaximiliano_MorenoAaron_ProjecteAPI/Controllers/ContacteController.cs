using Data;
using Entitats.ContacteClasses;
using Microsoft.AspNetCore.Mvc;

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
                return Ok("Missatge enviat");
            }
            catch (Exception ex)
            {
                return BadRequest(); 
            }
        }
    }
}
