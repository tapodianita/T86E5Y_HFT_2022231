using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Logic.Interfaces
{
  public interface IFlightsLogic
  {
    void Create(Flights item);
    void Delete(int id);
    Flights Read(int id);
    IQueryable<Flights> ReadAll();
    void Update(Flights item);
  }
}
