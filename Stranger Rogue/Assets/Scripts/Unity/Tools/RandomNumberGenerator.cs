using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
  private static int m_Seed;

  private static System.Random m_RNG;

  public string Seed;

  void Awake()
  {
    if (Seed == String.Empty)
    {
      m_Seed = DateTime.Now.Millisecond;
      Seed = m_Seed.ToString();
    }
    else
    {
      m_Seed = Seed.GetHashCode();
    }

    m_RNG = new System.Random(m_Seed);

    GameBoardFactory.Seed = m_Seed;
    ListExtensions.RNG = m_RNG;
  }

  public static int GetSeed()
  {
    return m_Seed;
  }

  public static System.Random GetRNG()
  {
    return m_RNG;
  }
}
