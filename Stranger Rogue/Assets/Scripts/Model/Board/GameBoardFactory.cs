using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class GameBoardFactory
{
  private static bool m_IsSeedProvided;
  private static int m_Seed;

  public static int Seed
  {
    get
    {
      if (!m_IsSeedProvided)
      {
        Seed = DateTime.Now.ToString().GetHashCode();
      }
      return m_Seed;
    }
    set
    {
      m_IsSeedProvided = true;
      m_Seed = value;
    }
  }

  public static float GrassPourcentage;

  public static BoardTileNeighbouring[,] CreateBoard(int width, int length)
  {
    var abstractBoard = CreateAbstractBoard(width, length);

    var board = new BoardTileNeighbouring[width, length];

    for (int i = 0; i < width; i++)
    {
      for (int j = 0; j < length; j++)
      {
        var newTile = new BoardTileNeighbouring(new BoardTile() { Type = abstractBoard[i, j] });
        if (i != 0)
        {
          newTile.Add(board[i - 1, j], NeighbourOccupancy.Left);
          board[i - 1, j].Add(newTile, NeighbourOccupancy.Right);
        }
        if (j != 0)
        {
          newTile.Add(board[i, j - 1], NeighbourOccupancy.Up);
          board[i, j - 1].Add(newTile, NeighbourOccupancy.Down);
        }
        board[i, j] = newTile;
      }
    }

    return board;
  }

  private static TileType[,] CreateAbstractBoard(int width, int length)
  {
    var board = new TileType[width, length];
    var rng = new Random(Seed);

    for (int i = 0; i < width; i++)
    {
      for (int j = 0; j < length; j++)
      {
        if (i % 3 == 0)
        {
          board[i, j] = TileType.Road;
        }
        else
        {
          if (j % 5 == 0)
          {
            board[i, j] = TileType.Road;
          }
          else
          {
            if (rng.NextDouble() < GrassPourcentage)
            {
              board[i, j] = TileType.Grass;
            }
            else
            {
              board[i, j] = TileType.Building;
            }
          }
        }
      }
    }

    return board;
  }

  private static TileType[,] CreateAbstractBoard2(int width, int length)
  {
    var board = new TileType[width, length];

    for (int i = 0; i < width; i++)
    {
      for (int j = 0; j < length; j++)
      {
        board[i, j] = TileType.Building;
      }
    }
    
    return board;
  }
}

