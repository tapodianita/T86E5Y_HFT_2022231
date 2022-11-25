using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using T86E5Y_HFT_2022231.Logic.Classes;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Repository.Interfaces;

namespace T86E5Y_HFT_2022231.Test
{
  [TestFixture]
  public class Testing
  {
    IAirlineLogic airlineLogic;
    IAirplaneLogic airplaneLogic;
    IManufacturerLogic manufacturerLogic;
    Mock<IRepository<Airline>> mockAirlineRepo;
    Mock<IRepository<Airplane>> mockAirplaneRepo;
    Mock<IRepository<Manufacturer>> mockManufacturerRepo;
    [SetUp]
    public void Init()
    {
      var airline1 = new Airline() { Id = 1, Name = "Wizz Air", HasBusinessClass = true };

      var manufacturer = new Manufacturer() { Id = 1, Name = "Boeing" };


      var airplane1 = new Airplane() { Id = 1, Name = "B734", Airlines = new List<Airline>() { airline1 }, Type = "utasszálító", YearOfManufacture = 1990, Manufacturer = manufacturer };
      var airplane2 = new Airplane() { Id = 2, Name = "B738", Airlines = new List<Airline>() { airline1 }, Type = "tehergép", YearOfManufacture = 2000, Manufacturer = manufacturer };
      var airplane3 = new Airplane { Id = 3, Name = "B752", Airlines = new List<Airline>() { airline1 }, Type = "utasszállító", YearOfManufacture = 1988, Manufacturer = manufacturer };

      airline1.Airplanes = new List<Airplane>() { airplane1, airplane2, airplane3 };
      manufacturer.Airplanes = new List<Airplane>() { airplane1, airplane2, airplane3 };


      mockAirlineRepo = new Mock<IRepository<Airline>>();
      mockAirlineRepo.Setup(m => m.ReadAll()).Returns(new List<Airline>() { airline1 }
          .AsQueryable());
      airlineLogic = new AirlineLogic(mockAirlineRepo.Object);


      mockManufacturerRepo = new Mock<IRepository<Manufacturer>>();
      mockManufacturerRepo.Setup(m => m.ReadAll()).Returns(new List<Manufacturer>() { manufacturer }
          .AsQueryable());
      manufacturerLogic = new ManufacturerLogic(mockManufacturerRepo.Object);

      mockAirplaneRepo = new Mock<IRepository<Airplane>>();
      mockAirplaneRepo.Setup(m => m.ReadAll()).Returns(new List<Airplane>() { airplane1, airplane2, airplane3 }
          .AsQueryable());
      airplaneLogic = new AirplaneLogic(mockAirplaneRepo.Object);
    }
  }
}
