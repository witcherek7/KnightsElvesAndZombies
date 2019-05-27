using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondSpawn : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        canvas.SetActive(true);
        GameObject.Find("KilledText").GetComponent<Text>().text = GameObject.Find("EnemiesCount").GetComponent<Count>().inTotal + " skeletors killed.";
    }
}
