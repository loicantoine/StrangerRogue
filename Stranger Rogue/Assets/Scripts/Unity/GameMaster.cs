using UnityEngine;

public class GameMaster : MonoBehaviour
{
  private static GameMaster m_Instance;

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

  public int MaxFoodPerTile;
  public int MaxSciencePerTile;
  public int MaxIndustryPerTile;
}

