using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rambo : CharacterClass
{
  public override string ClassName { get { return "Rambo"; } }

  public override int BaseAttack { get { return 7; } }

  public override int BaseDefense { get { return 5; } }

  public override int BaseHitPoint { get { return 100; } }

  public override int BaseStamina { get { return 100; } }
}
