using AutoMapper;
using Commander.Data;
using Commander.model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommanderController : ControllerBase
    {
        private readonly CommanderRepo _Repo;
        private readonly IMapper _mapper;
        public static IHostingEnvironment _environment;
        public CommanderController(){}
       /*public CommanderController(CommanderRepo repo , IMapper mapper )
       {
           _Repo = repo;
           _mapper = mapper;
           //_environment = environment;
       }*/
       
       [HttpGet("myname/{name}")]
       public ActionResult<string> getString(string name)
       {
           return name;
       }
    
        [HttpGet]
        public ActionResult <IEnumerable<CommanderReadDto>> getAppCommands()
        {
            var commandItems = _Repo.GetAppCommands();
            var readers = _mapper.Map<IEnumerable<CommanderReadDto>>(commandItems); 
            return Ok(readers);
        }
        [HttpGet("Id/{id}",Name="getCommandById")]
        public ActionResult <CommanderReadDto> getCommandById(int id)
        {
            var commandItem = _Repo.GetCommanderById(id);
            if(commandItem == null)
            {
                return NotFound();
            }
            CommanderReadDto reader =  _mapper.Map<CommanderReadDto>(commandItem);
            return Ok(reader);
        }
        [HttpPost]
        public ActionResult CreateCommand(CommanderCreateDto cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException();
            }
            var create = _mapper.Map<Command>(cmd);
            _Repo.CreateCommand(create);
            _Repo.SavingChanges();
            
            return CreatedAtRoute(nameof(getCommandById),new {Id = create.Id},create );
        }
         [HttpPut("{id}")]
        public ActionResult <Command> UpdateCommand(CommanderCreateDto cmd , int id)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException();
            }
            var commandItem = _Repo.GetCommanderById(id);
            if(commandItem == null)
            {
              return NotFound();
            
            }
             
            var create = _mapper.Map(cmd,commandItem);
            
            _Repo.UpdateCommand(create);
            _Repo.SavingChanges();
            return Ok(create); 
        }
       [HttpPatch("{id}")]
       public ActionResult PartialPatchCommand(int id , JsonPatchDocument<CommanderUpdateDto> patchDoc)
       {
            var commandItem = _Repo.GetCommanderById(id);
            if(commandItem == null)
            {
              return NotFound();
            
            }
            var commandUpdate = _mapper.Map<CommanderUpdateDto>(commandItem);
            patchDoc.ApplyTo(commandUpdate,ModelState);
            if(!TryValidateModel(commandUpdate))
            {
                return ValidationProblem(ModelState);
            }
            var patchCommand = _mapper.Map(commandUpdate,commandItem);
            _Repo.UpdateCommand(commandItem);
            _Repo.SavingChanges();
            return NoContent();
       }
       [HttpDelete("{id}")]
       public ActionResult<CommanderReadDto> DeleteCommandById(int id)
       {
            var commandItem = _Repo.GetCommanderById(id);
            if(commandItem == null)
            {
              return NotFound();
            
            }
            var deletedCommand = _mapper.Map<CommanderReadDto>(commandItem);
            _Repo.DeleteCommand(commandItem);
            _Repo.SavingChanges();
            return deletedCommand;
       }

        [HttpPost("~/api/command/upload")]
        public ActionResult<string> Post()
        {            
            var file = Request.Form.Files; //WOW!
            try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + file[0].FileName))
                    {
                        file[0].CopyTo(filestream);
                        filestream.Flush();
                        return  Ok(file[0]);
                    }
                }
                catch (Exception ex)
                {
                    return Ok(ex.ToString());
                }
            }

        }   
      
    }

