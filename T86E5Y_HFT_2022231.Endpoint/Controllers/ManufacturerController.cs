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
  public class ManufacturerController : ControllerBase
  {
    IManufacturerLogic logic;

    public ManufacturerController(IManufacturerLogic logic)
    {
      this.logic = logic;
    }

    [HttpGet]
    public IEnumerable<Manufacturer> ReadAll()
    {
      return logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Manufacturer Read(int id)
    {
      return logic.Read(id);
    }
    [HttpPost]
    public void Create([FromBody] Manufacturer value)
    {
      logic.Create(value);
    }

    [HttpPut]
    public void Update([FromBody] Manufacturer value)
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
