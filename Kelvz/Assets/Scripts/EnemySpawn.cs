using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    public GameObject enemy01, enemy02;
    public int multiplier;
    private int enemy01count = 1, enemy02count = 1;
    private bool isProducing = false;
    private int days;

    // Start is called before the first frame update
    void Start()
    {
        days = GameObject.Find("Canvas").GetComponent<Background>().days;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<Background>().hours < 7 && isProducing == false || GameObject.Find("Canvas").GetComponent<Background>().hours > 19 && isProducing == false)
        {
            isProducing = true;
            // for (int i = 0; i < enemy01count; i++)
            // {
            //     Instantiate(enemy01,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
            //     StartCoroutine(interval());
            // }
            // for (int i = 0; i < enemy02count; i++)
            // {
            //      Instantiate(enemy01,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
            //     StartCoroutine(interval());
            // }
            StartCoroutine(intervalEnemy1());
            StartCoroutine(intervalEnemy2());

        }
        if (GameObject.Find("Canvas").GetComponent<Background>().hours > 7 && GameObject.Find("Canvas").GetComponent<Background>().hours < 19 && isProducing == true)
        {
            isProducing = false;
        }
    }

    IEnumerator intervalEnemy1()
    {
        while (isProducing)
        {
            yield return new WaitForSeconds(5f-days/10/multiplier);
            Instantiate(enemy01, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }
    IEnumerator intervalEnemy2()
    {
        while (isProducing)
        {
            yield return new WaitForSeconds(20f-days/10/multiplier);
            Instantiate(enemy02, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }

}
