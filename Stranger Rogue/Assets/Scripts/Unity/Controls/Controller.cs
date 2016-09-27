using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Controller : MonoBehaviour
{
  public Camera CameraToControl;
  public Transform GameBoard;

  public float CameraSpeed;
  public float CameraZoomSpeed;

  public float CameraPanSpeed;

  private Vector3 m_LastMousePosition;

  public float MaxZoom;
  public float MinZoom;

  public void Update()
  {
    if (Input.GetAxis("Horizontal") > 0)
    {
      GameBoard.position += Vector3.left * CameraSpeed * Time.deltaTime;
    }
    else if (Input.GetAxis("Horizontal") < 0)
    {
      GameBoard.position += Vector3.right * CameraSpeed * Time.deltaTime;
    }

    if (Input.GetAxis("Vertical") > 0)
    {
      GameBoard.position += Vector3.down * CameraSpeed * Time.deltaTime;
    }
    else if (Input.GetAxis("Vertical") < 0)
    {
      GameBoard.position += Vector3.up * CameraSpeed * Time.deltaTime;
    }

    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    {
      if (CameraToControl.orthographicSize > CameraZoomSpeed * Time.deltaTime + MinZoom)
      {
        CameraToControl.orthographicSize -= CameraZoomSpeed * Time.deltaTime;
      }
    }
    else if (Input.GetAxis("Mouse ScrollWheel") < 0)
    {
      if (CameraToControl.orthographicSize < MaxZoom)
      {
        CameraToControl.orthographicSize += CameraZoomSpeed * Time.deltaTime;
      }
    }


    if (Input.GetKeyDown(KeyCode.Mouse1))
    {
      m_LastMousePosition = GetMouseHitPoint();
    }

    if (Input.GetKey(KeyCode.Mouse1))
    {
      var currentMousePosition = GetMouseHitPoint();
      if (m_LastMousePosition != Vector3.zero && currentMousePosition != Vector3.zero)
      {
        GameBoard.position += -(m_LastMousePosition - currentMousePosition);
      }

      m_LastMousePosition = currentMousePosition;
    }
  }

  private Vector3 VectorBuffer;
  private Vector3 GetMouseHitPoint()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var raycasthit = Physics2D.Raycast(ray.origin, ray.direction);
    VectorBuffer.Set(raycasthit.point.x, raycasthit.point.y, 0);
    return VectorBuffer;
  }
}
