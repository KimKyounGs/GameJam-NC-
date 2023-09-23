using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{  
    public static Event instance;
    
    public People people = new People();
    void Start()
    {   
        instance = this;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        // 대화 나오게 하기.
        Debug.Log(other);

        
    }   

}
