using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1GameManager : MonoBehaviour
{
    public static G1GameManager instance;

    public enum GameState
    {
        Play, Stop
    }
    public GameState state;

    [HideInInspector] public List<Window> runningWindow = new List<Window>();
    public void CheckPlayState(Window window)
    {
        runningWindow.Remove(window);
        if(runningWindow.Count == 0)
        {
            state = GameState.Play;
            CharacterMove.instance.StaticRigidbody(false);
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
