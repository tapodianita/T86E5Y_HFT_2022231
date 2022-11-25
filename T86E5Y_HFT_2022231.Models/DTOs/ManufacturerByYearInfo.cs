using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T86E5Y_HFT_2022231.Models.DTOs
{
  public class ManufacturerByYearInfo
  {
    public int Year { get; set; }
    public int ManufacturerCount { get; set; }
    public override string ToString()
    {
      return $"Year = {Year}, ManufacturerCount = {ManufacturerCount}";
    }
  }
}
