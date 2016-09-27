using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class CharacterClass
{
  public abstract string ClassName { get; }
  public abstract int BaseHitPoint { get; }
  public abstract int BaseStamina { get; }
  public abstract int BaseAttack { get; }
  public abstract int BaseDefense { get; }
}
