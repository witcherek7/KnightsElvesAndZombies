using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float parallaxSpeed;
    private GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            if(transform.position.x <= 242)
            {
                transform.Translate(new Vector2(parallaxSpeed * Time.deltaTime,0)); 
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            if(transform.position.x >= -3.20)
            {
                transform.Translate(new Vector2(-parallaxSpeed * Time.deltaTime,0)); 
            }

        }
        else {
            
        }
    }
}
