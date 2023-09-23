using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;

    private int _shipSpeed = 2;

    Rigidbody2D rid2D;
    
    void Start()
    {
        instance = this;
        rid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveShip();
    }

    void MoveShip() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Impulse);
            //transform.Traslate(new Vector3(0,_shipSpeed * Time.deltaTime,0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Impulse);
        }
    }
}
