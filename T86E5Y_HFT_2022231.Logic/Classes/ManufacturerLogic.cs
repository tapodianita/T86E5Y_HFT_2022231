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
  public class ManufacturerLogic : IManufacturerLogic
  {
    IRepository<Manufacturer> repo;

    public ManufacturerLogic(IRepository<Manufacturer> repo)
    {
      this.repo = repo;
    }

    public void Create(Manufacturer item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      repo.Create(item);
    }

    public void Delete(int id)
    {
      repo.Delete(id);
    }

    public Manufacturer Read(int id)
    {
      return repo.Read(id);
    }

    public IQueryable<Manufacturer> ReadAll()
    {
      return repo.ReadAll();
    }

    public void Update(Manufacturer item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      repo.Update(item);
    }
  }
}
