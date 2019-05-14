using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Armory : MonoBehaviour
{
    public GameObject archerButton;
    public GameObject warriorButton;
    public GameObject canvasText;
    private GameObject warriorButtonCopy, archerButtonCopy; //canvasTextCopy1, canvasTextCopy2;
    // Start is called before the first frame update
    private Text text1, text2;
    public void ShowButtons()
    {
        warriorButtonCopy = (GameObject)Instantiate(warriorButton, new Vector2(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y + 1.2f), Quaternion.identity);
        archerButtonCopy = (GameObject)Instantiate(archerButton, new Vector2(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y + 1.2f), Quaternion.identity);
        warriorButtonCopy.transform.parent = gameObject.transform;
        archerButtonCopy.transform.parent = gameObject.transform;
        // canvasTextCopy1 = (GameObject)Instantiate(canvasText, new Vector2(warriorButtonCopy.transform.position.x, gameObject.transform.position.y + 1.7f), Quaternion.identity);
        // canvasTextCopy2 = (GameObject)Instantiate(canvasText, new Vector2(archerButtonCopy.transform.position.x, gameObject.transform.position.y + 1.7f), Quaternion.identity);
        // canvasTextCopy1.transform.parent = gameObject.transform;
        // canvasTextCopy2.transform.parent = gameObject.transform;
        // text1 = canvasTextCopy1.transform.GetChild(0).gameObject.GetComponent<Text>();
        // text2 = canvasTextCopy2.transform.GetChild(0).gameObject.GetComponent<Text>();
        // ShowPrice();
        
    }

    // public void HidePrice()
    // {
    //     Destroy(canvasTextCopy1);
    //     Destroy(canvasTextCopy2);
    // }
    // public void ShowPrice()
    // {
        
    //     //text1.text = warriorButtonCopy.GetComponent<BuyTroopsButton>().price.ToString()+"$";
    //     //text2.text = archerButtonCopy.GetComponent<BuyTroopsButton>().price.ToString()+"$";
    // }

}
