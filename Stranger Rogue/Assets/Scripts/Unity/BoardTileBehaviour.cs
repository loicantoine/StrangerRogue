using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BoardTileBehaviour : PoolableObject
{
  public BoardTile Tile;

  public Sprite Sprite;
  public TileType Type;

  public List<GameObject> OptionnalSpriteList;

  public float ChanceOfSpriteAppearing;

  void Start()
  {
    Tile = new BoardTile() { Type = Type };
  }

  public void OnEnable()
  {
    foreach (var sprite in OptionnalSpriteList)
    {
      sprite.SetActive(RandomNumberGenerator.GetRNG().NextDouble() < ChanceOfSpriteAppearing);
    }
  }
}
