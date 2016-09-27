using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AlienRambo : CharacterClass
{
  public override string ClassName { get { return "RamboAlien"; } }

  public override int BaseAttack { get { return 7; } }

  public override int BaseDefense { get { return 3; } }

  public override int BaseHitPoint { get { return 100; } }

  public override int BaseStamina { get { return 75; } }
}
