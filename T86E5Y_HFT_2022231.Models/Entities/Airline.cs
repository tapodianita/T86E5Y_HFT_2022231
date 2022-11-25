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
  public class Airline
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(240)]
    [Required]
    public string Name { get; set; }
    [StringLength(240)]
    public string CallSign { get; set; }
    public bool HasBusinessClass { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Airplane> Airplanes { get; set; }
    public Airline()
    {
 
    }
    public Airline(string lines)
    {
      string[] line = lines.Split("#");
      this.Id = int.Parse(line[0]);
      this.Name = line[1];
      this.CallSign = line[2];
      this.HasBusinessClass = bool.Parse(line[3]);
    }
    public override string ToString()
    {
      return $"ID: {Id}, Name: {Name}, CallSign: {CallSign}, HasBusinessClass = {HasBusinessClass}";
    }
  }
}
