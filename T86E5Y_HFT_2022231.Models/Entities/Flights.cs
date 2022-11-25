using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace T86E5Y_HFT_2022231.Models.Entities
{
  public class Flights
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int AirplaneId { get; set; }
    public int AirlineId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Airplane Airplane { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Airline Airline { get; set; }
    public Flights()
    {

    }
    public Flights(string line)
    {
      var temp = line.Split("#");
      Id = int.Parse(temp[0]);
      AirplaneId = int.Parse(temp[1]);
      AirlineId = int.Parse(temp[2]);
    }
  }
}
