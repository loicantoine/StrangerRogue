using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFightMenu : MonoBehaviour
{
  public Button AttackButton;
  public Button HealButton;

  public void SetInteractable(bool interactable)
  {
    AttackButton.interactable = interactable;
    HealButton.interactable = interactable;
  }
}