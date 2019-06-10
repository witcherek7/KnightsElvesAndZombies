using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFather : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        gameObject.transform.parent.GetComponent<BuildButton>().buildingDestroyed();
    }
}
