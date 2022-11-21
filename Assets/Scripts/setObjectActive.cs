using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setObjectActive : MonoBehaviour
{
  public GameObject _Canvas;
  public void _SetActiveObject ()
  {
    _Canvas.SetActive(true);
  }
    public void _SetNonActiveObject ()
  {
    _Canvas.SetActive(false);
  }

}
