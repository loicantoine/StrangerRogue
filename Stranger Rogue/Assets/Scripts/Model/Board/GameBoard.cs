using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard
{
  public BoardTileNeighbouring[,] Board;

  public GameBoard(int width, int lendth)
  {
    Board = GameBoardFactory.CreateBoard(width, lendth);
  }
}
