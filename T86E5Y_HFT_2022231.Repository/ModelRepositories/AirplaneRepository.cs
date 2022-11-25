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
  public class AirplaneRepository : Repository<Airplane>, IRepository<Airplane>
  {
    public AirplaneRepository(AirplaneDbContext ctx) : base(ctx)
    {
    }
    public override Airplane Read(int id)
    {
      return ctx.AirPlanes.FirstOrDefault(a => a.Id == id);
    }
    public override void Update(Airplane item)
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
