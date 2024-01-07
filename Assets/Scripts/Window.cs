using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        G1GameManager.instance.state = G1GameManager.GameState.Stop;
        CharacterMove.instance.StaticRigidbody(true);
    }
    private void OnMouseDrag()
    {
        Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, newPos, 50 * Time.deltaTime);
    }
    private void OnMouseUp()
    {
        StartCoroutine(ReturnStandPoint());
    }


    IEnumerator ReturnStandPoint()
    {
        while (transform.position != standPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, standPoint, 50 * Time.deltaTime);
            yield return null;
        }
        G1GameManager.instance.state = G1GameManager.GameState.Play;
        CharacterMove.instance.StaticRigidbody(false);
    }
}
