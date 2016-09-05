
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour
{
  public Image FoodIcon;
  public Text FoodNumberText;
  public Image ScienceIcon;
  public Text ScienceNumberText;
  public Image IndustryIcon;
  public Text IndustryNumberText;
  public GameObject CapturedObject;

  [HideInInspector]
  public BoardTileBehaviour BoardTileBehaviour;

  public void OnCaptureBuildingClick()
  {
    Debug.Log("Capture building!");
    BoardTileBehaviour.CaptureTile();
  }
  public void OnSearchBuildingClick()
  {
    Debug.Log("Searching building!");
  }
  public void OnWaitClick()
  {
    Debug.Log("Wait on tile!");
  }
}