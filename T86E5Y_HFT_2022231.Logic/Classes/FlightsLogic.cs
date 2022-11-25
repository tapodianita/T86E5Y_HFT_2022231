using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Repository.Interfaces;

namespace T86E5Y_HFT_2022231.Logic.Classes
{
  public class FlightsLogic : IFlightsLogic
  {
    IRepository<Flights> repo;

    public FlightsLogic(IRepository<Flights> repo)
    {
      this.repo = repo;
    }

    public void Create(Flights item)
    {
      if (item.AirplaneId < 0) throw new Exception("AirplaneId error");
      if (item.AirlineId < 0) throw new Exception("AirlineId error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      this.repo.Create(item);
    }

    public void Delete(int id)
    {
      this.repo.Delete(id);
    }

    public Flights Read(int id)
    {
      return this.repo.Read(id);
    }

    public IQueryable<Flights> ReadAll()
    {
      return this.repo.ReadAll();
    }

    public void Update(Flights item)
    {
      if (item.AirplaneId <= 0) throw new Exception("AirplaneId error");
      if (item.AirlineId <= 0) throw new Exception("AirlineId error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      this.repo.Update(item);
    }
  }
}
