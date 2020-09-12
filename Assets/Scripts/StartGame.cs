using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void startGame() 
    {
        SceneManager.LoadScene("game");
    }

}
