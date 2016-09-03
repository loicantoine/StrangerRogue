using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Controller : MonoBehaviour
{
  public Camera CameraToControl;
  public float CameraSpeed;
  public float CameraZoomSpeed;

  private Vector3 m_LastMousePosition;

  public float MaxZoom;
  public float MinZoom;

  public void Update()
  {
    if (Input.GetAxis("Horizontal") > 0)
    {
      CameraToControl.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
    }
    else if (Input.GetAxis("Horizontal") < 0)
    {
      CameraToControl.transform.position += Vector3.left * CameraSpeed * Time.deltaTime;
    }

    if (Input.GetAxis("Vertical") > 0)
    {
      CameraToControl.transform.position += Vector3.up * CameraSpeed * Time.deltaTime;
    }
    else if (Input.GetAxis("Vertical") < 0)
    {
      CameraToControl.transform.position += Vector3.down * CameraSpeed * Time.deltaTime;
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

    if (Input.GetKey(KeyCode.Mouse0))
    {
      if (m_LastMousePosition != Vector3.zero)
      {
        CameraToControl.transform.position += m_LastMousePosition - Input.mousePosition;
      }
      m_LastMousePosition = Input.mousePosition;
    }
    else
    {
      m_LastMousePosition = Vector3.zero;
    }
  }
}
