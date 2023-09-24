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

    public static Event _event = null;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (_isWreckColliderOn)
        {
            if (_UseTelescope)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _wreck.NoUseTelesocpe();
                    _UseTelescope = false;
                    _bShipMove = true;
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    if (_event != null)
                    {
                        _wreck.NoUseTelesocpe();
                        _event.StartEvent();
                    }
                    else
                    {
                        _wreck.NoEvent();
                        _bShipMove = true;
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.R) && _UseTelescope != true)
            {
                _wreck.UseTelescope();
                _UseTelescope = true;
                _bShipMove = false;
            }
        }
    }
}
