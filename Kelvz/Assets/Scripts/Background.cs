using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public GameObject dayCloud;
    public GameObject nightCloud;
    public GameObject timeText;
    private float elapsed, elapsedNight, elapsedDay ;
    private int minutes = 0;
    private int hours = 7;
    private int dayTimeMinutes = 420;

    // Start is called before the first frame update
    // Start time should be 7:00
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 0.5f)
        {
            hours = dayTimeMinutes / 60;
            minutes = dayTimeMinutes % 60;

            if (minutes < 10)
            {
                timeText.GetComponent<Text>().text = hours.ToString() + ":0" + minutes.ToString();
            }
            else
            {
                timeText.GetComponent<Text>().text = hours.ToString() + ":" + minutes.ToString();
            }

            dayTimeMinutes += 1;
            elapsed = elapsed % 0.5f;


        }

        if(hours == 24)
        {
            dayTimeMinutes = 0;
        }

        if(hours > 19 && hours < 7)
        {
            
        }
        else
        {

        }



    }
}
