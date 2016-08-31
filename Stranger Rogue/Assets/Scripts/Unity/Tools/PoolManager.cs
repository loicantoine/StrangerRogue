using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
  private static PoolManager m_Instance;

  public static PoolManager Singleton
  {
    get
    {
      if (m_Instance == null)
      {
        m_Instance = FindObjectOfType<PoolManager>();
      }
      return m_Instance;
    }
  }

  private Dictionary<int, Queue<PoolableObject>> m_PoolDictionary = new Dictionary<int, Queue<PoolableObject>>();

  public void CreatePool(PoolableObject prefab, int size)
  {
    Debug.Log("Creating pool");
    var holder = new GameObject(prefab.name + " pool");
    holder.transform.parent = transform;
    holder.transform.position = Vector3.zero;

    var key = prefab.GetInstanceID();

    if (!m_PoolDictionary.ContainsKey(key))
    {
      m_PoolDictionary.Add(key, new Queue<PoolableObject>(size));

      for (int i = 0; i < size; i++)
      {
        var newObject = Instantiate(prefab);
        newObject.Init();
        newObject.transform.parent = holder.transform;
        m_PoolDictionary[key].Enqueue(newObject);
      }
    }
  }

  public PoolableObject GetObject(PoolableObject prefab)
  {
    var key = prefab.GetInstanceID();
    if (m_PoolDictionary.ContainsKey(key))
    {
      var obj = m_PoolDictionary[key].Dequeue();
      obj.PullObject();
      m_PoolDictionary[key].Enqueue(obj);
      return obj;
    }

    return null;
  }
}
