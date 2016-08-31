using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardTileNeighbouring
{
  private BoardTile m_Tile;

  public NeighbourOccupancy NeighbourOccupancy;

  public readonly Dictionary<NeighbourOccupancy, BoardTileNeighbouring> Neighbours = new Dictionary<NeighbourOccupancy, BoardTileNeighbouring>(4);

  public TileType Type { get { return m_Tile.Type; } }

  public BoardTileNeighbouring(BoardTile tile)
  {
    m_Tile = tile;
  }

  public bool Add(BoardTileNeighbouring neighbour, NeighbourOccupancy occupancy)
  {
    if (NeighbourOccupancy.HasFlag(occupancy))
    {
      return false;
    }

    NeighbourOccupancy |= occupancy;
    Neighbours.Add(occupancy, neighbour);

    return true;
  }

  public bool IsNeighbourHasType(NeighbourOccupancy occupancy, TileType type)
  {
    if (!NeighbourOccupancy.HasFlag(occupancy) || !Neighbours.ContainsKey(occupancy))
    {
      return false;
    }
    
    return Neighbours[occupancy].Type == type;
  }
}


