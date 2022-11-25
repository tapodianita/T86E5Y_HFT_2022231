using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Repository.Database;
using T86E5Y_HFT_2022231.Repository.Interfaces;

namespace T86E5Y_HFT_2022231.Repository.GenericRepository
{
  public abstract class Repository<T> : IRepository<T> where T : class
  {
    protected AirplaneDbContext ctx;

    protected Repository(AirplaneDbContext ctx)
    {
      this.ctx = ctx;
    }

    public void Create(T item)
    {
      ctx.Set<T>().Add(item);
      ctx.SaveChanges();
    }

    public void Delete(int id)
    {
      ctx.Set<T>().Remove(Read(id));
      ctx.SaveChanges();
    }

    public IQueryable<T> ReadAll()
    {
      return ctx.Set<T>();
    }
    public abstract T Read(int id);

    public abstract void Update(T item);
  }
}
