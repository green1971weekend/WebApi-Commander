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
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("Single")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetEntityByID(id);

            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            if (commandCreateDto == null)
            {
                throw new ArgumentNullException(nameof(commandCreateDto));
            }

            var command = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateEntity(command);
            _repository.SaveChanges();

            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandCreateDto commandCreateDto)
        {
            var commandModelFromRepo = _repository.GetEntityByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandCreateDto, commandModelFromRepo);

            _repository.UpdateEntity(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetEntityByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEntity(commandModelFromRepo);
            _repository.SaveChanges();

            return Ok();
        }
    }
}
