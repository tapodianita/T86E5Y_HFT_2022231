using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Repository.Interfaces;

namespace T86E5Y_HFT_2022231.Logic.Classes
{
  public class AirlineLogic : IAirlineLogic
  {
    IRepository<Airline> repo;

    public AirlineLogic(IRepository<Airline> repo)
    {
      this.repo = repo;
    }

    public void Create(Airline item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      this.repo.Create(item);
    }

    public void Delete(int id)
    {
      this.repo.Delete(id);
    }

    public Airline Read(int id)
    {
      return this.repo.Read(id);
    }

    public IQueryable<Airline> ReadAll()
    {
      return this.repo.ReadAll();
    }

    public void Update(Airline item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");

      this.repo.Update(item);
    }
    public IEnumerable<Airline> BusinessFlights()
    {
      var data = this.repo.ReadAll().Where(p => p.HasBusinessClass);
      return data;
    }
    public IEnumerable<PlaneInAirlineInfo> AirplaneAirlines()
    {
      var data = this.repo.ReadAll()
          .Select(x => new PlaneInAirlineInfo
          {
            AirlineName = x.Name,
            AirPlanesCount = x.Airplanes.Count()
          });
      return data;
    }
  }
}
