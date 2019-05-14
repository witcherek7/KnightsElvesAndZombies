using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    public GameObject parent;
    void OnMouseDown() 
    {
        parent = transform.parent.gameObject;
        parent.GetComponent<BuildButton>().ConfirmAction();
        Destroy(gameObject);
    }
}
