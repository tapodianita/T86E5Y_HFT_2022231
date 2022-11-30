using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Repository.Database
{
  public class AirplaneDbContext : DbContext
  {
    public virtual DbSet<Airplane> AirPlanes { get; set; }
    public virtual DbSet<Airline> Airlines { get; set; }
    public virtual DbSet<Flights> Flight { get; set; }
    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public AirplaneDbContext()
    {
      this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      if (!builder.IsConfigured)
      {
        builder
          .UseInMemoryDatabase("Airplane")
          .UseLazyLoadingProxies();
      }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Airplane>()
          .HasOne(airplane => airplane.Manufacturer)
          .WithMany(Manufacturer => Manufacturer.Airplanes)
          .HasForeignKey(x => x.ManufactureId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Airline>()
          .HasMany(x => x.Airplanes)
          .WithMany(x => x.Airlines)
          .UsingEntity<Flights>(
          x => x.HasOne(x => x.Airplane)
          .WithMany().HasForeignKey(x => x.AirplaneId).OnDelete(DeleteBehavior.Cascade),
          x => x.HasOne(x => x.Airline)
          .WithMany().HasForeignKey(x => x.AirlineId).OnDelete(DeleteBehavior.Cascade));


      modelBuilder.Entity<Airplane>().HasData(new Airplane[]
      {
                new Airplane("1#airliner#B734#1990#1"),
                new Airplane("2#airliner#B738#2000#1"),
                new Airplane("3#airliner#B752#1988#1"),
                new Airplane("4#airliner#A300#1985#2"),
                new Airplane("5#airliner#A330#1995#2"),
                new Airplane("6#airliner#A320#2000#2"),
                new Airplane("7#airliner#DH8D#2001#3"),
                new Airplane("8#airliner#AT72#1990#6"),
                new Airplane("9#airliner#RJ85#1985#4"),
                new Airplane("10#airliner#B763#1987#1"),
                new Airplane("11#airliner#B77W#1999#1"),
                new Airplane("12#airliner#E195#2006#5"),
                new Airplane("13#cargo#B744#1976#1")
      });
      modelBuilder.Entity<Airline>().HasData(new Airline[]
      {
                new Airline("1#WizzAir#WZZ#false"),
                new Airline("2#Rainer#RYR#false"),
                new Airline("3#Austrian#AUA#true"),
                new Airline("4#Norwegian#NOZ#true"),
                new Airline("5#Lufthansa#DLH#true"),
                new Airline("6#British Airways#BAW#true"),
                new Airline("7#Scandinavian Airlines#SAS#true"),
                new Airline("8#Eurowings#EWG#true"),
                new Airline("9#Turkish Airlines#THY#true"),
                new Airline("10#Emirates#UAE#true"),
                new Airline("11#Sun Express#SXS#true"),
                new Airline("12#Cargolux#CLX#false"),
                new Airline("13#DHL#DHL#false"),
                new Airline("14#Air France#AFR#true")
      });
      modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[]
      {
                            new Manufacturer("1#Boeing"),
                            new Manufacturer("2#Airbus"),
                            new Manufacturer("3#DeHavilland"),
                            new Manufacturer("4#Avro/Bae"),
                            new Manufacturer("5#Embraer"),
                            new Manufacturer("6#ATR")
      });
      modelBuilder.Entity<Flights>().HasData(new Flights[]
      {
                            new Flights("1#1#6"),
                            new Flights("2#10#12"),
                            new Flights("3#9#7"),
                            new Flights("4#6#8"),
                            new Flights("5#8#6"),
                            new Flights("6#7#1"),
                            new Flights("7#11#5"),
                            new Flights("8#5#13"),
                            new Flights("9#2#2"),
                            new Flights("10#3#5"),
                            new Flights("11#13#3"),
                            new Flights("12#4#4"),
                            new Flights("13#12#8"),
                            new Flights("14#3#9"),
                            new Flights("15#7#10"),
                            new Flights("16#2#14"),
                            new Flights("17#9#11"),
      });

    }

  }
}
