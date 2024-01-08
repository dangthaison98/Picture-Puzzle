using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Window : MonoBehaviour
{
    private Camera _camera;
    [HideInInspector] public Vector3 standPoint;

    private void Awake()
    {
        _camera = Camera.main;
        standPoint = transform.position;
    }

    RaycastHit2D hit;
    private void OnMouseDown()
    {
        StopAllCoroutines();
        G1GameManager.instance.CheckPlayState(this);
        G1GameManager.instance.state = G1GameManager.GameState.Stop;
        CharacterMove.instance.StaticRigidbody(true);
        gameObject.layer = 31;
    }
    private void OnMouseDrag()
    {
        Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, newPos, 50 * Time.deltaTime);
        hit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0f, LayerMask.GetMask("Window"));
    }
    private void OnMouseUp()
    {
        if(hit)
        {
            var window = hit.collider.GetComponent<Window>();
            var posHolder = standPoint;
            standPoint = window.standPoint;
            window.ActiveNewStandPos(posHolder);
        }
        StartCoroutine(ReturnStandPoint());
    }

    public void ActiveNewStandPos(Vector3 newPos)
    {
        standPoint = newPos;
        StartCoroutine(ReturnStandPoint());
    }
    IEnumerator ReturnStandPoint()
    {
        G1GameManager.instance.runningWindow.Add(this);
        while (transform.position != standPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, standPoint, 50 * Time.deltaTime);
            yield return null;
        }
        G1GameManager.instance.CheckPlayState(this);
        gameObject.layer = 7;
    }
}
