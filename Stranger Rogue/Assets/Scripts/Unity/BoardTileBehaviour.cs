using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BoardTileBehaviour : PoolableObject
{
  private int m_FoodAvailableResource;
  private int m_ScienceAvailableResource;
  private int m_IndustryAvailableResource;

  public BoardTile Tile;

  public Sprite Sprite;
  public TileType Type;

  public List<GameObject> OptionnalSpriteList;

  public float ChanceOfSpriteAppearing;

  public bool IsResourceAvailable;

  public GameObject Canvas;

  public Button ButtonOverlay;

  public Image FoodIcon;
  public Text FoodNumberText;
  public Image ScienceIcon;
  public Text ScienceNumberText;
  public Image IndustryIcon;
  public Text IndustryNumberText;

  void Start()
  {
    Tile = new BoardTile() { Type = Type };
    if (IsResourceAvailable)
    {
      m_FoodAvailableResource = RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxFoodPerTile);
      m_ScienceAvailableResource = RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxSciencePerTile);
      m_IndustryAvailableResource = RandomNumberGenerator.GetRNG().Next(0, GameMaster.Singleton.MaxIndustryPerTile);
      
      FoodNumberText.text = m_FoodAvailableResource.ToString();
      
      ScienceNumberText.text = m_ScienceAvailableResource.ToString();
      
      IndustryNumberText.text = m_IndustryAvailableResource.ToString();
    }
    else
    {
      FoodIcon.gameObject.SetActive(false);
      ScienceIcon.gameObject.SetActive(false);
      IndustryIcon.gameObject.SetActive(false);
    }
  }

  public void OnEnable()
  {
    foreach (var sprite in OptionnalSpriteList)
    {
      sprite.SetActive(RandomNumberGenerator.GetRNG().NextDouble() < ChanceOfSpriteAppearing);
    }
  }

  public void SetOverlayActive(bool isActive)
  {
    ButtonOverlay.gameObject.SetActive(isActive);
  }

}
