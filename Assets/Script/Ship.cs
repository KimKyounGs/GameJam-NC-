using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;

    private float _shipSpeed = 3.0f;

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
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            //rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Impulse);
            transform.Translate(new Vector3(0,_shipSpeed * Time.deltaTime,0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Impulse);
            transform.Translate(new Vector3(-_shipSpeed * Time.deltaTime,0,0));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Impulse);
            transform.Translate(new Vector3(0,-_shipSpeed * Time.deltaTime,0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Impulse);
            transform.Translate(new Vector3(_shipSpeed * Time.deltaTime,0,0));
        }
    }
}
