using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;

private float _shipSpeed = 0.5f;

    private float _nowRotation = 90;

    Rigidbody2D rid2D;

    Animator animator;
    
    void Start()
    {
        instance = this;
        rid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameBase._bShipMove)
        {
            MoveShip();
        }
    }

    void MoveShip() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            //rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, _shipSpeed), ForceMode2D.Impulse);
            transform.position = new Vector3(transform.position.x, transform.position.y + _shipSpeed, transform.position.z);
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(-_shipSpeed,0), ForceMode2D.Impulse);
            transform.position = new Vector3(transform.position.x - _shipSpeed, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0,0,_nowRotation);
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(0, -_shipSpeed), ForceMode2D.Impulse);
            transform.position = new Vector3(transform.position.x, transform.position.y - _shipSpeed, transform.position.z);
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Force);
            //rid2D.AddForce(new Vector2(_shipSpeed,0), ForceMode2D.Impulse);
            transform.position = new Vector3(transform.position.x + _shipSpeed, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0,0,-_nowRotation);
            Paddle.instance.MovePaddle();
        }
    }
}
