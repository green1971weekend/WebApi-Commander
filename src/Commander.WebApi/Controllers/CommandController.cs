using AutoMapper;
using Commander.Common.Interfaces;
using Commander.DAL.DTO;
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
        private readonly IMapper _mapper;

        public CommandController(IRepository<Command> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandDto>> GetAllCommands()
        {
            var items = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommandDto>>(items));
        }

        [HttpGet("Single")]
        public ActionResult<CommandDto> GetCommandById(int id)
        {
            var item = _repository.GetEntityByID(id);

            if (item != null)
            {
                return Ok(_mapper.Map<CommandDto>(item));
            }
            return NotFound();
        }
    }
}
