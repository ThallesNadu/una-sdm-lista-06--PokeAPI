using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerPokeAPI.Models;

public class Pokemon
{
    public int id { get; set; }
    public string Name { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
}
