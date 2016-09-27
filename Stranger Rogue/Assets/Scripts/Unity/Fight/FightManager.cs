using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class FightManager : MonoBehaviour
{
  public PlayerFightMenu PlayerMenuGameObject;

  private bool PlayerPlaying = true;

  private List<Character> PlayerCharacters;
  private List<Character> AlienCharacters;

  public void Start()
  {
    PlayerCharacters = new List<Character>();
    PlayerCharacters.Add(new Character(new Rambo()));
    PlayerMenuGameObject.AttackButton.onClick.RemoveAllListeners();
    PlayerMenuGameObject.AttackButton.onClick.AddListener(() => Attack());
    PlayerMenuGameObject.HealButton.onClick.RemoveAllListeners();
    PlayerMenuGameObject.HealButton.onClick.AddListener(() => Heal());

    AlienCharacters = new List<Character>();
    AlienCharacters.Add(new Character(new AlienRambo()));
  }

  public void Update()
  {
    if (PlayerPlaying)
    {
      SetupPlayerTurn();
    }
    else
    {
      ComputeAlienTurn();
    }
  }

  public void SetupPlayerTurn()
  {
    PlayerMenuGameObject.SetInteractable(true);
  }
  private int Turn = 0;
  public void Attack()
  {
    if (AlienCharacters.First().TakeDamage(PlayerCharacters.First().CharacterSheet.Attack))
    {
      PlayerPlaying = !PlayerPlaying;
      Turn++;
    }
    else
    {
      Debug.Log("Joueur victorieux !");
    }
    Log();
  }

  public void Heal()
  {
    PlayerCharacters.First().Heal(10);
    PlayerPlaying = !PlayerPlaying;
    Turn++;
    Log();
  }

  public void ComputeAlienTurn()
  {
    if (PlayerCharacters.First().TakeDamage(AlienCharacters.First().CharacterSheet.Attack))
    {
      PlayerPlaying = !PlayerPlaying;
      Turn++;
    }
    else
    {
      Debug.Log("Alien victorieux !");
    }
    Log();
  }

  void Log()
  {
    Debug.Log("Turn : " + Turn + " - Player Life = " + PlayerCharacters.First().CurrentHitPoint + " - Alien Life = " + AlienCharacters.First().CurrentHitPoint);
    //Debug.Log("Player Life = " + PlayerCharacters.First().CurrentHitPoint);
    //Debug.Log("Alien Life = " + AlienCharacters.First().CurrentHitPoint);
  }
}
