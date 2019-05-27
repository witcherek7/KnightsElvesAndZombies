using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
    private GameObject text;
    public string textName;


    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find(textName).gameObject;
        text.GetComponent<Count>().howMany +=1;
        text.GetComponent<Count>().inTotal +=1;
        text.GetComponent<Count>().Recount();
    }

    void OnDestroy() {
        if(text){ // ????????????????????????????????????????????????? nie wiem czy tu spoko tak, ale null wyrzuca
         text.GetComponent<Count>().howMany -=1;
         text.GetComponent<Count>().Recount();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
