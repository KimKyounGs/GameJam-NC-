using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship instance;

    private float _shipSpeed = 1f;

    // private int _direction = 0;
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
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(new Vector3(0, _shipSpeed * Time.deltaTime, 0));
            /*
            transform.position = new Vector3(transform.position.x, transform.position.y + _shipSpeed, transform.position.z);
            if (_direction != 0)
            {
                transform.eulerAngles = new Vector3(0,0,0);
                _direction = 0;
            }
            */
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-_shipSpeed * Time.deltaTime, 0, 0));
            /*
            transform.position = new Vector3(transform.position.x - _shipSpeed, transform.position.y, transform.position.z);
            if (_direction != 1)
            {
                transform.eulerAngles = new Vector3(0,0,90);
                _direction = 1;
            }
            */
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -_shipSpeed * Time.deltaTime, 0));
            /*
            transform.position = new Vector3(transform.position.x, transform.position.y - _shipSpeed, transform.position.z);
            if (_direction != 2)
            {
                transform.eulerAngles = new Vector3(0,0,180);
                _direction = 2;
            }
            */
            Paddle.instance.MovePaddle();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(_shipSpeed * Time.deltaTime, 0, 0));
            /*
            transform.position = new Vector3(transform.position.x + _shipSpeed, transform.position.y, transform.position.z);
            if (_direction != 3)
            {
                transform.eulerAngles = new Vector3(0,0,-90);
                _direction = 3;
            }
            */
            Paddle.instance.MovePaddle();
        }
    }
}
