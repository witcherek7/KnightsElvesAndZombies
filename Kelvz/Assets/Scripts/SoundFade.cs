using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class SoundFade : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject camera;
    private float soundlevel = 1;
    private float distance;
    void Start()
    {
        camera = GameObject.Find("Main Camera").gameObject;
        soundlevel = gameObject.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        distance = camera.transform.position.x - gameObject.transform.position.x;
        //Debug.Log(distance);
        if(Abs(distance)<5)
        {
            //Debug.Log("zanik");
            soundlevel = 1 - distance/5;
            Debug.Log(soundlevel);
        }
        else
        {
            //Debug.Log("Zero");
            soundlevel = 0;
        }
    }
}
