using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Window : MonoBehaviour
{
    private Camera _camera;
    private Vector3 standPoint;
    private void Awake()
    {
        _camera = Camera.main;
        standPoint = transform.position;
    }

    private void OnMouseDown()
    {
        StopAllCoroutines();
    }
    private void OnMouseDrag()
    {
        Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.Lerp(transform.position, newPos, 15 * Time.deltaTime);
    }
    private void OnMouseUp()
    {
        StartCoroutine(ReturnStandPoint());
    }


    IEnumerator ReturnStandPoint()
    {
        while (transform.position != standPoint)
        {
            transform.position = Vector3.Lerp(transform.position, standPoint, 15 * Time.deltaTime);
            yield return null;
        }
    }
}
