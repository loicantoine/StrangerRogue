using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameBoardBehaviour : MonoBehaviour
{
  private GameBoard m_BoardModel;

  public float TileWidth;
  public float WallWidth;

  public int GameBoardWidth;
  public int GameBoardLength;

  public PoolableObject ExteriorWall;
  public PoolableObject InteriorWall;

  public List<BoardTileBehaviour> TileList;

  public BoardTileBehaviour CrossRoad;

  public RectTransform Canvas;

  public ResourcePanel TileUIPanelPrefab;

  [Range(0,1)]
  public float GrassPourcentage;

  void Start()
  {
    GameBoardFactory.GrassPourcentage = GrassPourcentage;

    m_BoardModel = new GameBoard(GameBoardWidth, GameBoardLength);

    var xOffset = -(((GameBoardWidth - 1) * TileWidth) / 2);
    var yOffset = (((GameBoardLength - 1) * TileWidth) / 2);

    Canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (((GameBoardWidth) * TileWidth)));
    Canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (((GameBoardLength) * TileWidth)));

    var collider = GetComponent<BoxCollider2D>();
    collider.size = Vector2.right * (((GameBoardWidth) * TileWidth)) + Vector2.up * (((GameBoardLength) * TileWidth));

    for (int i = 0; i < GameBoardWidth; i++)
    {
      for (int j = 0; j < GameBoardLength; j++)
      {
        var currentTile = m_BoardModel.Board[i, j];

        if (TileList.Any(t =>
        t.Type ==
        m_BoardModel.Board[i, j]
        .Type))
        {
          var obj = Instantiate(TileList.Where(t => t.Type == currentTile.Type).ToList().GetRandomObject());
          
          var x = xOffset + i * TileWidth;
          var y = yOffset - j * TileWidth;
          obj.transform.position = new Vector3(x, y);
          
          
          switch (currentTile.Type)
          {
            case TileType.Road:
              #region Wall
              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Up, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y + TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Right, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x + TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Left, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x - TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Down, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y - TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }
              #endregion
              #region Road Allignement

              //Debug.LogWarning("Road (" + i + ", " + j + ") = " + currentTile.Neighbours.Count(n => n.Value.Type == TileType.Road));

              if (currentTile.Neighbours.Count(n => n.Value.Type == TileType.Road) > 2)
              {
                obj.Destroy();
                obj = Instantiate(CrossRoad);

                obj.transform.position = new Vector3(x, y);

                obj.transform.parent = transform;
              }
              else if (currentTile.Neighbours.Count(n => n.Value.Type == TileType.Road) == 2 && ((i == 0 && j == 0) || (i == 0 && j == GameBoardLength - 1) || (i == GameBoardWidth - 1 && j == 0) || (i == GameBoardWidth - 1 && j == GameBoardLength - 1)))
              {
                obj.Destroy();
                obj = Instantiate(CrossRoad);

                obj.transform.position = new Vector3(x, y);

                obj.transform.parent = transform;
              }
              else if ((currentTile.IsNeighbourHasType(NeighbourOccupancy.Left, TileType.Road)) && (currentTile.IsNeighbourHasType(NeighbourOccupancy.Left, TileType.Road)))
              {
                obj.transform.Rotate(Vector3.forward * 90);
               // currentBehaviour.Canvas.transform.Rotate(-Vector3.forward * 90);
              }
              #endregion
              break;
            case TileType.Building:
              #region Wall
              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Up, TileType.Building))
              {
                var wall = Instantiate(InteriorWall);
                wall.transform.position = new Vector3(x, y + TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Right, TileType.Building))
              {
                var wall = Instantiate(InteriorWall);
                wall.transform.position = new Vector3(x + TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Left, TileType.Building))
              {
                var wall = Instantiate(InteriorWall);
                wall.transform.position = new Vector3(x - TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Down, TileType.Building))
              {
                var wall = Instantiate(InteriorWall);
                wall.transform.position = new Vector3(x, y - TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }

              if (!currentTile.NeighbourOccupancy.HasFlag(NeighbourOccupancy.Up))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y + TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }

              if (!currentTile.NeighbourOccupancy.HasFlag(NeighbourOccupancy.Right))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x + TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (!currentTile.NeighbourOccupancy.HasFlag(NeighbourOccupancy.Left))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x - TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (!currentTile.NeighbourOccupancy.HasFlag(NeighbourOccupancy.Down))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y - TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }
              #endregion
              #region Random Rotation
              var rotation = Vector3.forward * 90 * RandomNumberGenerator.GetRNG().Next(0, 3);
              obj.transform.Rotate(rotation);
              //currentBehaviour.Canvas.transform.Rotate(-rotation);
              #endregion
              break;
            case TileType.Grass:
              #region Wall
              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Up, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y + TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Right, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x + TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Left, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x - TileWidth / 2, y);
                wall.transform.parent = transform;
              }

              if (currentTile.IsNeighbourHasType(NeighbourOccupancy.Down, TileType.Building))
              {
                var wall = Instantiate(ExteriorWall);
                wall.transform.position = new Vector3(x, y - TileWidth / 2);
                wall.transform.Rotate(Vector3.forward * 90);
                wall.transform.parent = transform;
              }
              #endregion
              break;
            default:
              Debug.LogWarning("The type " + currentTile.Type + " has no behaviour defined");
              break;
          }

          var ui = Instantiate(TileUIPanelPrefab);

          ui.transform.SetParent(Canvas, false);

          var rectTransform = ui.GetComponent<RectTransform>();

          rectTransform.anchorMin = Vector2.one * 0.5f;
          rectTransform.anchorMax = Vector2.one * 0.5f;
          rectTransform.anchoredPosition = Vector2.right * x + Vector2.up * y;
          ui.name += " (" + currentTile.Type + ")" + "(" + i + ", " + j + ")" + " (" + obj.name + ")";

          obj.ResourcePanel = ui;
          obj.transform.parent = transform;
          obj.UpdateResourcePanel();
        }
      }
    }
  }

}
