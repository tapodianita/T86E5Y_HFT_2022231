using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Models.Entities;

namespace T86E5Y_HFT_2022231.Models.DTOs
{
  public class ManufacturerPlaneInfo
  {
    public Manufacturer Manufacturer { get; set; }
    public int AllPlane { get; set; }
    public double AvgToAllPlanePercent { get; set; }
    public override string ToString()
    {
      return $"Manufacturer = {Manufacturer.Name}, AllPlane = {AllPlane}, AvgToAllPlanePercent = {AvgToAllPlanePercent}%";
    }
  }
}
