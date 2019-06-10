using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenDeath : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject musicDeath;
    void Start()
    {
        musicDeath = GameObject.Find("Music_Women_Death").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnDestroy()
    {
        musicDeath.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        musicDeath.GetComponent<AudioSource>().Play();
    }

}
