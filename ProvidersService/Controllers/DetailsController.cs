using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProvidersService.Data;

namespace DetailsServices.Controllers
{

    [Route("api/c/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IProviderRepo _repository;
        private readonly IMapper _mapper;

        public DetailsController(IProviderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Provider Service");

            return Ok("Inbound test of from Details Controller");
        }
    }
}