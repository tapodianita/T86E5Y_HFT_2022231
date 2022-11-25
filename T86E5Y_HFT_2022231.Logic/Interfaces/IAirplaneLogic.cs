using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Logic.Interfaces
{
  public interface IAirplaneLogic
  {
    void Create(Airplane item);
    void Delete(int id);
    Airplane Read(int id);
    IQueryable<Airplane> ReadAll();
    void Update(Airplane item);
  }
}
