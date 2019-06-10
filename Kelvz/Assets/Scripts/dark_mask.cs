using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dark_mask : MonoBehaviour
{
    private GameObject mask;
    // Start is called before the first frame update
    void Start()
    {
        mask = GameObject.Find("Dark");
        mask.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
