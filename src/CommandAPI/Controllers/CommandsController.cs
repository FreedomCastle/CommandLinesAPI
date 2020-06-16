using System.Collections.Generic;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;
        public CommandsController(CommandContext context) => _context = context;
        
        //Get: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            return _context.CommandItems;
        }
        
       
        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get ()
        // {
        //     return new string[] {"this", "is", "hard", "coded"};
        // }
    }
}