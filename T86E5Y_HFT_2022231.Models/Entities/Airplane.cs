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
  public class Airplane
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(240)]
    public string Type { get; set; }
    [StringLength(240)]
    [Required]
    public string Name { get; set; }
    [Range(1900, 2022)]
    public int YearOfManufacture { get; set; }
    public int ManufactureId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual Manufacturer Manufacturer { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Airline> Airlines { get; set; }
    public Airplane(string lines)
    {
      string[] line = lines.Split("#");
      this.Id = int.Parse(line[0]);
      this.Type = line[1];
      this.Name = line[2];
      this.YearOfManufacture = int.Parse(line[3]);
      this.ManufactureId = int.Parse(line[4]);
    }
    public Airplane()
    {

    }
    public override string ToString()
    {
      return $"ID: {Id}, Name: {Name}, YearOfManufacture: {YearOfManufacture}, ManufacturerId = {ManufactureId}";
    }
  }
}
