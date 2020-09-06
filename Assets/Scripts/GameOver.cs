using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject starControl;
   
    public void restartGame()
    {
        SceneManager.LoadScene("game");
        starControl.GetComponent<StarControll>().currentTime = 0;
        starControl.GetComponent<StarControll>().nextUpdate = 1;
    }

}
