using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x <= 24.2)
            
           //transform.position = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(new Vector2(speed * Time.deltaTime,0));        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x >= -24.6)
            {
            //transform.position = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(new Vector2(-speed * Time.deltaTime,0)); 
            }
        }

    }
}
