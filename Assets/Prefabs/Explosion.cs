using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float delay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Boom").GetComponent<AudioSource>().Play();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);        
    }

}
