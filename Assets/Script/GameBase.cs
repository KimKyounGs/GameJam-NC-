using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBase : MonoBehaviour
{
    public static GameBase instance;

    public static bool _bShipMove = true;

    public static bool _isWreckColliderOn = false;

    public static bool _UseTelescope = false;

    public static Wreck _wreck = null;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (_isWreckColliderOn)
        {
            Debug.Log("_isWreckColliderOn = " + _isWreckColliderOn);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _wreck.UseTelescope();
                _UseTelescope = true;
            }

            if (_UseTelescope)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _wreck.NoUseTelesocpe();
                }
            }
        }
    }
}
