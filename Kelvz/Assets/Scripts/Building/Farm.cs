using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public GameObject peasantButton;
    private GameObject peasantButtonCopy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void ShowButton()
    {
        peasantButtonCopy = (GameObject)Instantiate(peasantButton, new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 1.2f), Quaternion.identity);
        peasantButtonCopy.transform.parent = gameObject.transform;


    }
}
