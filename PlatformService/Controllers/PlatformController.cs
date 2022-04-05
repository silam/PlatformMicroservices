using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

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

        [HttpGet("{id}")]
        
        public ActionResult<PlatformReadDto> GetPlatFormById(int id)
        {
            var platformItem = _repo.GetPlatformById(id);

            if (platformItem != null){
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            

            }

            return NotFound("Not Found ID");

        }

    }
}