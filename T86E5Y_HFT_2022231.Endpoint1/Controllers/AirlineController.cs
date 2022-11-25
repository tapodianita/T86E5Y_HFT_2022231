using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Endpoint.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class AirlineController : ControllerBase
  {
    IAirlineLogic logic;

    public AirlineController(IAirlineLogic logic)
    {
      this.logic = logic;
    }

    [HttpGet]
    public IEnumerable<Airline> ReadAll()
    {
      return logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Airline Read(int id)
    {
      return logic.Read(id);
    }
    [HttpPost]
    public void Create([FromBody] Airline value)
    {
      logic.Create(value);
    }

    [HttpPut]
    public void Update([FromBody] Airline value)
    {
      logic.Update(value);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      logic.Delete(id);
    }
  }
}
