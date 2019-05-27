using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    // Start is called before the first frame update
     public string level = "Level";
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TaskOnClick() {
        Debug.Log("Button clicked");
        SceneManager.LoadScene(level);
    }
}
