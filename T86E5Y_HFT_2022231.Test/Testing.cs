using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using T86E5Y_HFT_2022231.Logic.Classes;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.DTOs;
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
    [Test]
    public void TestAirLineCreate()
    {
      var testairline = new Airline() { Name = "Szuper Bt." };

      airlineLogic.Create(testairline);

      mockAirlineRepo.Verify(x => x.Create(testairline), Times.Once);
    }
    [Test]
    public void TestManufactureCreateFail()
    {
      var manufacture = new Manufacturer() { Id = -10 };
      Assert.Throws<Exception>(() =>
      {
        manufacturerLogic.Create(manufacture);
      });
      mockManufacturerRepo.Verify(x => x.Create(manufacture), Times.Never);
    }
    [Test]
    public void TestPlaneCreateFail()
    {
      var airplane = new Airplane();
      Assert.Throws<Exception>(() =>
      {
        airplaneLogic.Create(airplane);
      });
      mockAirplaneRepo.Verify(x => x.Create(airplane), Times.Never);
    }
    [Test]
    public void BusinessFlightsTest()
    {
      var datas = airlineLogic.BusinessFlights();

      Assert.That(datas.Count() == 1);
      Assert.AreEqual(datas.First().Name, "Wizz Air");
    }
    [Test]
    public void AirplaneAirlines()
    {
      var datas = airlineLogic.AirplaneAirlines();


      Assert.That(datas.Count() == 1);
      Assert.AreEqual(datas.First().AirlineName, "Wizz Air");
      Assert.AreEqual(datas.First().AirPlanesCount, 3);
    }
    [Test]
    public void ManufacturerByYearStatics()
    {
      var datas = airplaneLogic.ManufacturerByYearStatics();

      Assert.That(datas.First().Year == 1988);
      Assert.That(datas.First().ManufacturerCount == 1);
    }
    [Test]
    public void GetPlaneByManufacturerStaticsTest()
    {
      var data = manufacturerLogic.GetPlaneByManufacturer().First();
      var neededResult = new ManufacturerPlaneInfo()
      {
        AllPlane = 3,
        AvgToAllPlanePercent = 100,
        Manufacturer = new Manufacturer() { Name = "Boeing" }
      };

      Assert.AreEqual(data.AvgToAllPlanePercent, neededResult.AvgToAllPlanePercent);
      Assert.AreEqual(data.AllPlane, neededResult.AllPlane);
      Assert.AreEqual(data.Manufacturer.Name, neededResult.Manufacturer.Name);

    }
    [Test]
    public void ManufacturerByYearStaticsTest()
    {
      Assert.DoesNotThrow(() => {
        var data = manufacturerLogic.ManufacturerAllAirPlineStatics("Boeing");
        Assert.That(data.Count() == 3);
      });

    }
    [Test]
    public void UpdateAirline()
    {
      var airline = airlineLogic.ReadAll().FirstOrDefault(x => x.Id == 1);
      airline.Name = "Tested";
      Assert.DoesNotThrow(() => {
        airlineLogic.Update(airline);
      });
      mockAirlineRepo.Verify(x => x.Update(airline), Times.Once);
    }
    [Test]
    public void UpdateManufacturer()
    {
      var manufact = manufacturerLogic.ReadAll().FirstOrDefault(x => x.Id == 1);
      manufact.Name = "as";
      Assert.Throws<Exception>(() => {
        manufacturerLogic.Update(manufact);
      });
      mockManufacturerRepo.Verify(x => x.Update(manufact), Times.Never);
    }
  }
}
