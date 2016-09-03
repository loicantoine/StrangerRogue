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

      FoodIcon.gameObject.SetActive(m_FoodAvailableResource > 0);
      FoodNumberText.gameObject.SetActive(m_FoodAvailableResource > 0);
      FoodNumberText.text = m_FoodAvailableResource.ToString();

      ScienceIcon.gameObject.SetActive(m_ScienceAvailableResource > 0);
      ScienceNumberText.gameObject.SetActive(m_ScienceAvailableResource > 0);
      ScienceNumberText.text = m_ScienceAvailableResource.ToString();

      IndustryIcon.gameObject.SetActive(m_IndustryAvailableResource > 0);
      IndustryNumberText.gameObject.SetActive(m_IndustryAvailableResource > 0);
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
