using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class decreaseTime : MonoBehaviour
{

    public Text textTime;
    public AudioSource bonusEnd;
    public GameObject player;

    public int initialTime = 60;
    public int currentTime = 0;
    public int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime;
        textTime.text = "SHOT BONUS: " + currentTime;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Time.time >= nextUpdate )
        {

            currentTime--;
            textTime.text = "SHOT BONUS: " + currentTime;

            if (currentTime <= 0)
            {
                if (player.gameObject != null)
                {
                    player.GetComponent<shipContol>().doubleShot = false;
                    player.GetComponent<shipContol>().quadShot = false;
                    bonusEnd.Play();
                }
                gameObject.SetActive(false);
            }


            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        }

    }

    public void resetCurrentTime()
    {
        currentTime = initialTime;
    }
}
