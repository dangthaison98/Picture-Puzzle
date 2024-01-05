using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1GameManager : MonoBehaviour
{
    public static G1GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
