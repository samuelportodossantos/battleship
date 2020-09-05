using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
    public void restartGame()
    {
        SceneManager.LoadScene("game");
    }

}
