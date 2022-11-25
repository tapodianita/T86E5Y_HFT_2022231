using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Logic.Interfaces
{
  public interface IManufacturerLogic
  {
    void Create(Manufacturer item);
    void Delete(int id);
    Manufacturer Read(int id);
    IQueryable<Manufacturer> ReadAll();
    void Update(Manufacturer item);
    IEnumerable<ManufacturerPlaneInfo> GetPlaneByManufacturer();
    IEnumerable<Airplane> ManufacturerAllAirPlineStatics(string manufacturer);
  }
}
