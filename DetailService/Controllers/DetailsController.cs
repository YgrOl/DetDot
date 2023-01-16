using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DetailService.Data;
using DetailService.Dtos;
using DetailService.Models;
using DetailService.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailRepo _repository;
        private readonly IMapper _mapper;
        private readonly IProviderDataClient _detailDataClient;

        public DetailsController(
            IDetailRepo repository, 
            IMapper mapper,
            IProviderDataClient detailDataClient)
        {
            _repository =  repository;
            _mapper = mapper;
            _detailDataClient = detailDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DetailReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Details....");

            var detailItem = _repository.GetAllDetails();

            return Ok (_mapper.Map<IEnumerable<DetailReadDto>>(detailItem));
        }

        [HttpGet("{id}", Name = "GetDetailById")]
        public ActionResult<DetailReadDto> GetDetailById(int id)
        {
            var detailItem = _repository.GetDetailById(id);
            if (detailItem != null)
            {
                return Ok(_mapper.Map<DetailReadDto>(detailItem));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<DetailReadDto>> CreateDetail(DetailCreateDto detailCreateDto)
        {
            var detailModel = _mapper.Map<Detail>(detailCreateDto);
            _repository.CreateDetail(detailModel);
            _repository.SaveChanges();

            var detailReadDto = _mapper.Map<DetailReadDto>(detailModel);

            try
            {
                await _detailDataClient.SendDetailToCommand(detailReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }



            return CreatedAtRoute(nameof(GetDetailById), new { Id = detailReadDto.Id}, detailReadDto);
        }

    }
}