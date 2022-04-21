using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        #region Props & Ctor

        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            var list = _platformRepo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(list));
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public ActionResult<IEnumerable<PlatformReadDto>> GetById([FromRoute] int id)
        {
            var data = _platformRepo.GetById(id);
            return Ok(_mapper.Map<PlatformReadDto>(data));
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> Create([FromBody] PlatformCreateDto model)
        {
            var platformModel = _mapper.Map<Platform>(model);
            _platformRepo.Create(platformModel);
            _platformRepo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}