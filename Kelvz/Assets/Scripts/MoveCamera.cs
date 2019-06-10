using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{

    public float speed = 25f;
    [SerializeField] private float parallaxSpeed = 24f;
    [SerializeField] private GameObject background;

    // void Start() {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x <= 146.7)
            {
            
           //transform.position = new Vector2(speed * Time.deltaTime, 0);
                transform.Translate(new Vector2(speed * Time.deltaTime,0)); 
                if (background)
                    background.transform.Translate(new Vector2(parallaxSpeed * Time.deltaTime,0)); 


                // if (parallax){
                //    parallax.Speed = parallaxSpeed;
                // }
            }       
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x >= -3.20)
            {
                // if (parallax) {
                //     parallax.Speed = -parallaxSpeed;
                // }
                //transform.position = new Vector2(-speed * Time.deltaTime, 0);
                transform.Translate(new Vector2(-speed * Time.deltaTime,0)); 
                if (background)
                    background.transform.Translate(new Vector2(-parallaxSpeed * Time.deltaTime,0)); 

            }
        }
        // else {
        //     if(parallax){
        //         parallax.Speed = 0.0f;
        //         }
        // }

        
    if(Input.GetKey(KeyCode.Escape))
    {
        Application.Quit();
    }
    }
    
}
