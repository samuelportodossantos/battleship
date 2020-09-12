using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text startGameText;
    

    private int secondTimeCounter = 0;
    private float halfSecondTimeCounter = 0;

    private float timeSpeed = 0.1f;

    private bool colorTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        // Atualizações por segundo
        if ( Time.time >= secondTimeCounter ) {
            perSecondUpdate();
            secondTimeCounter = Mathf.FloorToInt(Time.time) + 1;
        }

        // Atualizações por meio segundo
        if ( Time.time >= halfSecondTimeCounter ) {
            halfSecondUpdate();
            halfSecondTimeCounter = Time.time + timeSpeed;
        }
        
    }

    void perSecondUpdate()
    {
        
    }

    void halfSecondUpdate()
    {
        colorTime = !colorTime;
        if ( colorTime ) {
            startGameText.color = Color.red;
        } else {
            startGameText.color = Color.white;
        }

    }


}
