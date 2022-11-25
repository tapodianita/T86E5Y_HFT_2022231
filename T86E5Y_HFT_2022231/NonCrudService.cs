using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.DTOs;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Client
{
  internal class NonCrudService
  {
    private RestService rest;

    public NonCrudService(RestService rest)
    {
      this.rest = rest;
    }
    public void BusinessFlights()
    {
      var items = rest.Get<Airline>($"NonCrud/BusinessFlights");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();
    }
    public void AirplaneAirlines()
    {
      var items = rest.Get<PlaneInAirlineInfo>($"NonCrud/AirplaneAirlines");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();
    }
    public void ManufacturerByYearStatics()
    {
      var items = rest.Get<ManufacturerByYearInfo>($"NonCrud/ManufacturerByYearStatics");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();
    }
    public void GetPlaneByManufacturer()
    {
      var items = rest.Get<ManufacturerPlaneInfo>($"NonCrud/GetPlaneByManufacturer");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();
    }
    public void ManufacturerAllAirPlineStatics()
    {
      Console.Write("Name = ");
      string name = Console.ReadLine();
      var items = rest.Get<Airplane>($"NonCrud/ManufacturerAllAirPlineStatics?name={name}");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();

    }
  }
}
