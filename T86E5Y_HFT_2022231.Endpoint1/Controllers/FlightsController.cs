using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Endpoint.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class FlightsController : ControllerBase
  {
    IFlightsLogic logic;

    public FlightsController(IFlightsLogic logic)
    {
      this.logic = logic;
    }

    [HttpGet]
    public IEnumerable<Flights> ReadAll()
    {
      return logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Flights Read(int id)
    {
      return logic.Read(id);
    }
    [HttpPost]
    public void Create([FromBody] Flights value)
    {
      logic.Create(value);
    }

    [HttpPut]
    public void Update([FromBody] Flights value)
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
