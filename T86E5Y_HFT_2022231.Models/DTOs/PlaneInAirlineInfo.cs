using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Models.DTOs
{
  public class PlaneInAirlineInfo
  {
    public string AirlineName { get; set; }
    public int AirPlanesCount { get; set; }
    public override string ToString()
    {
      return $"AirlineName = {AirlineName}, AirPlanesCount = {AirPlanesCount}";
    }
  }
}
