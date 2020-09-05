using UnityEngine;

public class balaControl : MonoBehaviour
{

    public int balaSpeed = 100;
    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, this.balaSpeed * Time.deltaTime, 0));
        
        if ( transform.position.y > 10 )
        {
            Destroy(bala);
        }

    }


}
