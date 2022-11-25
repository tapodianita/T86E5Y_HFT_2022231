using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Repository.Database;
using T86E5Y_HFT_2022231.Repository.GenericRepository;
using T86E5Y_HFT_2022231.Repository.Interfaces;

namespace T86E5Y_HFT_2022231.Repository.ModelRepositories
{
  public class ManufacturerRepository : Repository<Manufacturer>, IRepository<Manufacturer>
  {
    public ManufacturerRepository(AirplaneDbContext ctx) : base(ctx)
    {
    }
    public override Manufacturer Read(int id)
    {
      return ctx.Manufacturers.FirstOrDefault(a => a.Id == id);
    }

    public override void Update(Manufacturer item)
    {
      var old = Read(item.Id);
      foreach (var prop in old.GetType().GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual) && p.Name != "Id"))
      {
        prop.SetValue(old, prop.GetValue(item));
      }
      ctx.SaveChanges();
    }
  }
}
