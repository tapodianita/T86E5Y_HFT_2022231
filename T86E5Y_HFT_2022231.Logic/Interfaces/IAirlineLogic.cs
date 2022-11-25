using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Logic.Interfaces
{
  public interface IAirlineLogic
  {
    void Create(Airline item);
    void Delete(int id);
    Airline Read(int id);
    IQueryable<Airline> ReadAll();
    void Update(Airline item);
    IEnumerable<Airline> BusinessFlights();
    IEnumerable<PlaneInAirlineInfo> AirplaneAirlines();
  }
}
