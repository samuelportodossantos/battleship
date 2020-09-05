using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public GameObject menu;
    public Text bestScoreText;

    public void open()
    {
        Time.timeScale = 0;
        this.menu.SetActive(true);
    }

    public void close()
    {
        Time.timeScale = 1;
        this.menu.SetActive(false);
    }

    public void resetBestScore()
    {
        if ( PlayerPrefs.HasKey("score"))
        {
            print("resetando best score!");
            PlayerPrefs.SetInt("score", 0);
            bestScoreText.text = "BEST SCORE: 0";
        }
    }

    public void resetGame()
    {
        this.close();
        SceneManager.LoadScene("game");
    }

}
