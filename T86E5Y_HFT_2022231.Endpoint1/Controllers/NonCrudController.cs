using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Models.DTOs;

namespace T86E5Y_HFT_2022231.Endpoint.Controllers
{

  [Route("[controller]/[action]")]
  [ApiController]
  public class NonCrudController : ControllerBase
  {
    IAirlineLogic airlineLogic;
    IAirplaneLogic airplaneLogic;
    IManufacturerLogic manufacturerLogic;

    public NonCrudController(IAirlineLogic airlineLogic, IAirplaneLogic airplaneLogic, IManufacturerLogic manufacturerLogic)
    {
      this.airlineLogic = airlineLogic;
      this.airplaneLogic = airplaneLogic;
      this.manufacturerLogic = manufacturerLogic;
    }
    [HttpGet]
    public IEnumerable<Airline> BusinessFlights()
    {
      return airlineLogic.BusinessFlights();
    }
    [HttpGet]
    public IEnumerable<PlaneInAirlineInfo> AirplaneAirlines()
    {
      return airlineLogic.AirplaneAirlines(); // nem jooo
    }
    [HttpGet]
    public IEnumerable<ManufacturerByYearInfo> ManufacturerByYearStatics()
    {
      return airplaneLogic.ManufacturerByYearStatics(); // ez se
    }
    [HttpGet]
    public IEnumerable<ManufacturerPlaneInfo> GetPlaneByManufacturer()
    {
      return manufacturerLogic.GetPlaneByManufacturer(); // jav all plane stat
    }
    [HttpGet]
    public IEnumerable<Airplane> ManufacturerAllAirPlineStatics([FromQuery] string name)
    {
      return manufacturerLogic.ManufacturerAllAirPlineStatics(name);
    }

  }
}
