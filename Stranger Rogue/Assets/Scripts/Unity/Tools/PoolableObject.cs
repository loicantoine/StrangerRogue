
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
  public virtual void PullObject()
  {
    gameObject.SetActive(true);
  }

  public virtual void Init()
  {
    gameObject.SetActive(false);
  }

  public virtual void Destroy()
  {
    gameObject.SetActive(false);
  }
}

