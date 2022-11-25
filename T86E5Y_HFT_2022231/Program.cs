using System;
using ConsoleTools;
using T86E5Y_HFT_2022231.Client;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231
{
  class Program
  {
    static void Main(string[] args)
    {
      RestService rest = new RestService("http://localhost:33356/");
      CrudService crud = new CrudService(rest);
      NonCrudService nonCrud = new NonCrudService(rest);

      var airplaneSubMenu = new ConsoleMenu(args, level: 1)
      .Add("List", () => crud.List<Airplane>())
      .Add("Create", () => crud.Create<Airplane>())
      .Add("Delete", () => crud.Delete<Airplane>())
      .Add("Update", () => crud.Update<Airplane>())
      .Add("Exit", ConsoleMenu.Close);

      var airLineSubMenu = new ConsoleMenu(args, level: 1)
      .Add("List", () => crud.List<Airline>())
      .Add("Create", () => crud.Create<Airline>())
      .Add("Delete", () => crud.Delete<Airline>())
      .Add("Update", () => crud.Update<Airline>())
      .Add("Exit", ConsoleMenu.Close);

      var manufacturerSubMenu = new ConsoleMenu(args, level: 1)
       .Add("List", () => crud.List<Manufacturer>())
       .Add("Create", () => crud.Create<Manufacturer>())
       .Add("Delete", () => crud.Delete<Manufacturer>())
       .Add("Update", () => crud.Update<Manufacturer>())
       .Add("Exit", ConsoleMenu.Close);

      var flightsSubMenu = new ConsoleMenu(args, level: 1)
      .Add("List", () => crud.List<Flights>())
      .Add("Create", () => crud.Create<Flights>())
      .Add("Delete", () => crud.Delete<Flights>())
      .Add("Update", () => crud.Update<Flights>())
      .Add("Exit", ConsoleMenu.Close);

      var statsSubMenu = new ConsoleMenu(args, level: 1)
      .Add("BusinessFlights", () => nonCrud.BusinessFlights())
      .Add("GetPlaneByManufacturer", () => nonCrud.GetPlaneByManufacturer())
      .Add("ManufacturerAllAirPlineStatics", () => nonCrud.ManufacturerAllAirPlineStatics())
      .Add("ManufacturerByYearStatics", () => nonCrud.ManufacturerByYearStatics())
      .Add("AirplaneAirlines", () => nonCrud.AirplaneAirlines())
      .Add("Exit", ConsoleMenu.Close);

      var menu = new ConsoleMenu(args, level: 0)
      .Add("Airplane", () => airplaneSubMenu.Show())
      .Add("Airline", () => airLineSubMenu.Show())
      .Add("Manufacturer", () => manufacturerSubMenu.Show())
      .Add("Flights", () => flightsSubMenu.Show())
      .Add("Non-CRUD", () => statsSubMenu.Show())
      .Add("Exit", ConsoleMenu.Close);

      menu.Show();
    }
  }
}
