using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public GameObject dayCloud;
    public GameObject nightCloud;
    public GameObject timeText, Music_Day, Music_Night;
    private float elapsed, elapsedNight, elapsedDay;
    private int minutes = 0;
    public int hours = 7;
    public int days = 0;
    private int dayTimeMinutes = 3*420;
    private float opacity = 1f;
    private GameObject mask;

    // Start is called before the first frame update
    // Start time should be 7:00
    void Start()
    {
        nightCloud = GameObject.Find("RedMoonBackground");
        mask = GameObject.Find("Dark");

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
            days += 1;
            GameObject.Find("Player_Day_Text").GetComponent<Text>().text = "Day " + days;
            dayTimeMinutes = 0;
            hours = 0;
            minutes = 0;
        }

        if (hours > 19 || hours < 7)
        {
            // Debug.Log("Włączamy noc");

            // włączamy nocne tło
            if(!nightCloud.active){
                nightCloud.SetActive(true);
                // Debug.Log("Nightcloud set active: "+nightCloud.name.ToString());
            }
            if(mask){
                if(!mask.active){
                    mask.SetActive(true);
                }
            }
            // 
            if (opacity > 0)
            {
                // // 
                // nightCloud = GameObject.Find("RedMoonBackground");
                // nightCloud.SetActive(true);
                // // 
                //Debug.Log("Getting darker");
                elapsedDay += Time.deltaTime;
                if (elapsedDay >= 0.5f)
                {
                    // Debug.Log("Getting Darker");

                    elapsedDay = elapsedDay % 0.5f;
                    opacity = opacity - 0.02f;

                    Music_Day.GetComponent<AudioSource>().volume = opacity;
                    Music_Night.GetComponent<AudioSource>().volume = 1 - opacity;
                    
                    dayCloud.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
                    if(mask){
                        mask.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (1-opacity)*0.5f);
                    }

                }
            }
        }
        else
        {
            if (opacity < 1)
            {
                //Debug.Log("Getting lighter");
                elapsedDay += Time.deltaTime;
                if (elapsedDay >= 0.5f)
                {

                    Music_Day.GetComponent<AudioSource>().volume = opacity;
                    Music_Night.GetComponent<AudioSource>().volume = 1 - opacity;
                    elapsedDay = elapsedDay % 0.5f;
                    opacity = opacity + 0.02f;

                    dayCloud.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
                    mask.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (1-opacity)*0.5f);


                }
            }
            else {
                // wyłączamy nocne tło
                if(nightCloud.active){
                    // Debug.Log("Wyłączamy komponent nocy");
                    nightCloud.SetActive(false);
                }
                if (mask){
                    if (mask.active){
                        mask.SetActive(false);
                    }
                }
 
                // 
            }
        }



    }
}
