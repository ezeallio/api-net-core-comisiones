using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using ModelsDAL;
using Enums;
using ModelsDTO;

namespace LandingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesmanController : ControllerBase
    {
        private readonly ISalesmanService _salesmanService;

        public SalesmanController(ISalesmanService salesmanService)
        {
            _salesmanService = salesmanService;
        }

        [HttpGet("{description=}")]
        public ActionResult<IEnumerable<PackageDTO>> GetByDescription(string description)
        {
            return _salesmanService.GetPackages(description);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PackageItemDTO> GetById(int id)
        {
            return _salesmanService.GetPackage(id);
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult PostCalculateComission([FromBody] TravelDTO travel)
        {
            Object result;
            try
            {
                result = _salesmanService.CalculateComission(travel.clientType, travel.passengers, travel.nights, travel.idsPackages);
            }
            catch(Exception e)
            {
                result = e.Message;
            }

            return result.GetType() == typeof(double) ? Ok(result) : StatusCode(400, result);
        }
    }
}