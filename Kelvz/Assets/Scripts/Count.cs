using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public int howMany = 0;
    public int inTotal = 0;
    private string myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = gameObject.GetComponent<Text>().text;
        gameObject.GetComponent<Text>().text = myText + howMany;

    }
    public void Recount()
    {
        gameObject.GetComponent<Text>().text = myText + howMany;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
