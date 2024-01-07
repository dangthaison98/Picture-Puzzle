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

    private void Awake()
    {
        instance = this;
    }
}
