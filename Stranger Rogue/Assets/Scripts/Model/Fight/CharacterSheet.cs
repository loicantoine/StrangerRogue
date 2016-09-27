using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharacterSheet
{
  public int CurrentLevel;
  public CharacterClass CharacterClass;

  public int MaxHitPoints { get { return CharacterClass.BaseHitPoint; } }
  public int MaxStamina { get { return CharacterClass.BaseStamina; } }

  public int Attack { get { return CharacterClass.BaseAttack; } }
  public int Defense { get { return CharacterClass.BaseDefense; } }

  public CharacterSheet(CharacterClass characterClass)
  {
    CharacterClass = characterClass;
    CurrentLevel = 1;
  }

  public void LevelUp()
  {
    CurrentLevel++;
  }
}