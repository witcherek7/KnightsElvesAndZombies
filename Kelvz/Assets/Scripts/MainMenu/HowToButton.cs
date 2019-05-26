using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToButton : MonoBehaviour
{
    public GameObject HowToPlayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if(HowToPlayCanvas.activeSelf)
            HowToPlayCanvas.SetActive(false);
        else
        {
            HowToPlayCanvas.SetActive(true);
        }
    }
}
