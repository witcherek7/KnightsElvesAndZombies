using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end_of_game : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other) {
        if (canvas){
            Debug.Log("canvas exists, something triggered");
            if(other.gameObject.CompareTag("Enemy")){
                Debug.Log("Enemy triggered end of game");
                canvas.SetActive(true);
                GameObject.Find("KilledText").GetComponent<Text>().text = GameObject.Find("EnemiesCount").GetComponent<Count>().inTotal + " skeletors killed.";
            }
        }
    }
}
