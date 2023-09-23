using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBase : MonoBehaviour
{
    public static GameBase instance;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
