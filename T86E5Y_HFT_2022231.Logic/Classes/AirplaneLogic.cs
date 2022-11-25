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
  public class AirplaneLogic : IAirplaneLogic
  {
    IRepository<Airplane> repo;

    public AirplaneLogic(IRepository<Airplane> repo)
    {
      this.repo = repo;
    }

    public void Create(Airplane item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");
      if (item.Id != 0) throw new Exception("Id Autoincrement");
      this.repo.Create(item);
    }

    public void Delete(int id)
    {
      this.repo.Delete(id);
    }

    public Airplane Read(int id)
    {
      return this.repo.Read(id);
    }

    public IQueryable<Airplane> ReadAll()
    {
      return this.repo.ReadAll();
    }

    public void Update(Airplane item)
    {
      if (item.Name is null || item.Name.Length < 2 || item.Name.Length > 50) throw new Exception("Name error");
      this.repo.Update(item);
    }

  }
}
