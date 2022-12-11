using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sales.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private readonly IBloodBankRepository _bloodBanktRespository;
        private readonly IConfiguration _configuration;

        public BloodBankController(IBloodBankRepository bloodBankRepository, IConfiguration configuration)
        {
            _bloodBanktRespository = bloodBankRepository;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetAllBloodBank()
        {
            List<ControlBlood.Entity.BloodBank.BloodBank> bloodankList = _bloodBanktRespository.GetAll().ToList();
            return Ok(bloodankList);
        }

        [HttpPost]
        public IActionResult InsertBloodBank([FromBody] ControlBlood.Entity.BloodBank.BloodBank bloodBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_bloodBanktRespository.Create(bloodBank));
        }
    }
}
