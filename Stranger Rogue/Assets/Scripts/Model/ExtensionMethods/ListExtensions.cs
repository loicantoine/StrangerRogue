using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ListExtensions
{
  public static Random RNG;
  
  public static T GetRandomObject<T>(this List<T> list)
  {   
    if (RNG == null)
    {
      RNG = new Random((int)DateTime.UtcNow.Ticks);
    }
    var index = RNG.Next(0, list.Count);
    return list[index];
  }
}
