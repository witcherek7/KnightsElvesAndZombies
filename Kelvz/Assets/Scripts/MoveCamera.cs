using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 25f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x <= 242)
            
           //transform.position = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(new Vector2(speed * Time.deltaTime,0));        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x >= -3.20)
            {
            //transform.position = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(new Vector2(-speed * Time.deltaTime,0)); 
            }
        }

    }
}
