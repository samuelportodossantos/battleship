using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused = false;
    public AudioSource bgSound;
    
    private void pause ()
    {
        Time.timeScale = 0;
        bgSound.Pause();
    }

    private void unPause()
    {
        Time.timeScale = 1;
        bgSound.UnPause();
    }

    public void setPause()
    {
        paused = !paused;

        if (paused)
        {
            pause();
        } else
        {
            unPause();
        }
    }

}
