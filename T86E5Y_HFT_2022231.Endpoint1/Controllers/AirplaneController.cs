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
  public class AirplaneController : ControllerBase
  {
    IAirplaneLogic logic;

    public AirplaneController(IAirplaneLogic logic)
    {
      this.logic = logic;
    }

    [HttpGet]
    public IEnumerable<Airplane> ReadAll()
    {
      return logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Airplane Read(int id)
    {
      return logic.Read(id);
    }
    [HttpPost]
    public void Create([FromBody] Airplane value)
    {
      logic.Create(value);
    }

    [HttpPut]
    public void Update([FromBody] Airplane value)
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
