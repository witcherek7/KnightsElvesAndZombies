using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public GameObject dayCloud;
    public GameObject nightCloud;
    public GameObject timeText;
    private float elapsed, elapsedNight, elapsedDay;
    private int minutes = 0;
    private int hours = 7;
    private int dayTimeMinutes = 420;
    private float opacity = 1f;

    // Start is called before the first frame update
    // Start time should be 7:00
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 0.2f)
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
            elapsed = elapsed % 0.2f;


        }

        if (hours == 24)
        {
            dayTimeMinutes = 0;
            hours = 0;
            minutes = 0;
        }

        if (hours > 19 || hours < 7)
        {
            if (opacity > 0)
            {
                Debug.Log("Getting darker");
                elapsedDay += Time.deltaTime;
                if (elapsedDay >= 0.5f)
                {
                    elapsedDay = elapsedDay % 0.5f;
                    opacity = opacity - 0.02f;

                    dayCloud.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);

                }
            }
        }
        else
        {
            if (opacity < 1)
            {
                Debug.Log("Getting lighter");
                elapsedDay += Time.deltaTime;
                if (elapsedDay >= 0.5f)
                {
                    elapsedDay = elapsedDay % 0.5f;
                    opacity = opacity + 0.02f;

                    dayCloud.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);

                }
            }
        }



    }
}
