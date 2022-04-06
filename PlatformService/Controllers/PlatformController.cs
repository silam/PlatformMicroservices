using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController: ControllerBase {
        private IPlatformRepo _repo;
        private IMapper _mapper;

       
        public PlatformController(IPlatformRepo  repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("-- Gettring Platfoms");
            var platformItem = _repo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name="GetPlatFormById")]
        
        public ActionResult<PlatformReadDto> GetPlatFormById(int id)
        {
            var platformItem = _repo.GetPlatformById(id);

            if (platformItem != null){
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            

            }

            return NotFound("Not Found ID");

        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto _createDto)
        {
            var platformModel = _mapper.Map<Platform>(_createDto);
            _repo.CreatePlatform(platformModel);
            _repo.SaveChanges();

            var PlatformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            // create statuscode 201 
            return CreatedAtRoute(nameof(GetPlatFormById), new { Id = PlatformReadDto.Id}, PlatformReadDto);

        }
    }
}