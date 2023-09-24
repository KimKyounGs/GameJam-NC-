using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearGet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Pear.instance.GetPear();
        Destroy(gameObject);
    }   
}
