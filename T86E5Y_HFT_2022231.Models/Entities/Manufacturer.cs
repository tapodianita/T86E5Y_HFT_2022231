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
  public class Manufacturer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(240)]
    [Required]
    public string Name { get; set; }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Airplane> Airplanes { get; set; }

    public Manufacturer(string lines)
    {
      string[] line = lines.Split("#");
      this.Id = int.Parse(line[0]);
      this.Name = line[1];
    }
    public Manufacturer()
    {

    }

  }
}
