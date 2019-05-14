using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public Text text;
    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 2f)
        {
            elapsed = elapsed % 2f;
            text.text = "";
        }

    }

    public void DisplayMessage(string message)
    {
        text.text = message;
        elapsed = 0;
    }
}
