using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        GameObject.Find("EnemySpawn2").GetComponent<EnemySpawn>().enabled = true;
    }
}
