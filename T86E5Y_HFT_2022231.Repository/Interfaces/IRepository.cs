﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T86E5Y_HFT_2022231.Repository.Interfaces
{
  public interface IRepository<T> where T : class
  {
    IQueryable<T> ReadAll();
    T Read(int id);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
  }
}
