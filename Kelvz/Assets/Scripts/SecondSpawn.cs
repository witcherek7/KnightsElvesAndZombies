using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondSpawn : MonoBehaviour
{
    public GameObject canvas;

    void OnDestroy()
    {
        if (canvas){
            canvas.SetActive(true);
            GameObject.Find("KilledText").GetComponent<Text>().text = GameObject.Find("EnemiesCount").GetComponent<Count>().inTotal + " skeletors in total.";
        }
    }
}
