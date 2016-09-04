using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BoardTileBehaviour : PoolableObject
{
  public BoardTile Tile;

  public Sprite Sprite;
  public TileType Type;

  public List<GameObject> OptionnalSpriteList;

  public float ChanceOfSpriteAppearing;

  public bool IsResourceAvailable;
  
  public ResourcePanel ResourcePanel;

  void Awake()
  {
    Tile = new BoardTile(Type, RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxFoodPerTile),
                               RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxFoodPerTile),
                               RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxIndustryPerTile));
  }

  public void OnEnable()
  {
    foreach (var sprite in OptionnalSpriteList)
    {
      sprite.SetActive(RandomNumberGenerator.GetRNG().NextDouble() < ChanceOfSpriteAppearing);
    }
  }

  public void UpdateResourcePanel()
  {
    if (ResourcePanel != null)
    {
      if (IsResourceAvailable)
      {
        ResourcePanel.FoodNumberText.text = Tile.FoodAvailableResource.ToString();
        ResourcePanel.ScienceNumberText.text = Tile.ScienceAvailableResource.ToString();
        ResourcePanel.IndustryNumberText.text = Tile.IndustryAvailableResource.ToString();
        ResourcePanel.FoodIcon.gameObject.SetActive(true);
        ResourcePanel.ScienceIcon.gameObject.SetActive(true);
        ResourcePanel.IndustryIcon.gameObject.SetActive(true);
      }
      else
      {
        ResourcePanel.FoodIcon.gameObject.SetActive(false);
        ResourcePanel.ScienceIcon.gameObject.SetActive(false);
        ResourcePanel.IndustryIcon.gameObject.SetActive(false);
      }
    }
  }

  public void SetOverlayActive(bool isActive)
  {
    ResourcePanel.gameObject.SetActive(isActive);
  }

}
