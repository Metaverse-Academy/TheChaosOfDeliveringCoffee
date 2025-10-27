using UnityEngine;

public class SoundMNG : MonoBehaviour
{


    [SerializeField] private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player")) GoInside();
    }
   

    public void GoOutside()
    {
        

        audioSource.volume = 0.109f;


    }

    public void GoInside()
    {


        audioSource.volume = 1;

    }
}
