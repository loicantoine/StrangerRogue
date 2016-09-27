using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Character
{
  public CharacterSheet CharacterSheet;
  public int CurrentHitPoint;
  public int CurrentStamina;
  public int CurrentExperience;

  public Character(CharacterClass characterClass)
  {
    CharacterSheet = new CharacterSheet(characterClass);
    CurrentHitPoint = CharacterSheet.MaxHitPoints;
    CurrentStamina = CharacterSheet.MaxStamina;
    CurrentExperience = 0;
  }

  // Return true if the character survives the hit
  public bool TakeDamage(int hitDamage)
  {
    CurrentHitPoint -= hitDamage;
    return CurrentHitPoint > 0;
  }

  public void Heal(int healedAmount)
  {
    CurrentHitPoint = Math.Min(CurrentHitPoint + healedAmount, CharacterSheet.MaxHitPoints);
  }

  // reutrn true if the character has leveled up
  public bool AddExperience(int experience)
  {
    CurrentExperience += experience;
    if (CurrentExperience > 100)
    {
      CurrentExperience = CurrentExperience - ((CurrentExperience % 100) * 100);
      CharacterSheet.LevelUp();
      return true;
    }
    return false;
  }

  public void PostFightRoutine()
  {
    CurrentStamina += Math.Min(CharacterSheet.MaxStamina / 10, CharacterSheet.MaxStamina);
  }
}
