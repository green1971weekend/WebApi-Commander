using Commander.Common.Interfaces;
using Commander.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// Class controller which allows to operate with requests for commands.
    /// </summary>
    public class CommandController : ControllerBase
    {
        private readonly IRepository<Command> _repository;

        public CommandController(IRepository<Command> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var items = _repository.GetAll().ToList();
            return Ok(items);
        }

        [HttpGet("getUser")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var item = _repository.GetEntityByID(id);

            return Ok(item);
        }
    }
}
