using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class EnumExtension
{
  public static bool HasFlag(this NeighbourOccupancy cell, NeighbourOccupancy testedFlag)
  {
    return (cell & testedFlag) == testedFlag;
  }
}
