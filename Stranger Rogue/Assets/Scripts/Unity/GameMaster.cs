using UnityEngine;

public class GameMaster : MonoBehaviour
{
  private static GameMaster m_Instance;
  private GameBoardPosition m_PositionOnBoard;

  public int MaxFoodPerTile;
  public int MaxSciencePerTile;
  public int MaxIndustryPerTile;
  public GameBoardBehaviour GameBoard;

  public static GameMaster Singleton
  {
    get
    {
      if (m_Instance == null)
      {
        m_Instance = FindObjectOfType<GameMaster>();
      }
      return m_Instance;
    }
  }

  void Start()
  {
    
  }

}

public struct GameBoardPosition
{
  public int x;
  public int y;
}
