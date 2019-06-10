using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenDeath : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject musicDeath;
    void Start()
    {
        musicDeath = GameObject.Find("Music_Men_Death").gameObject;
    }


    void OnDestroy()
    {
        musicDeath.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        musicDeath.GetComponent<AudioSource>().Play();
    }
}
