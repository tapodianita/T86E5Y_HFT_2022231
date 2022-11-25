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
    public IEnumerable<Airplane> AirPlanes { get; set; }
    public override string ToString()
    {
      string text = "";
      AirPlanes.ToList().ForEach(szoveg => text += szoveg + ",");
      return $"AirlineName = {AirlineName}, AirPlanes = {text}";
    }
  }
}
