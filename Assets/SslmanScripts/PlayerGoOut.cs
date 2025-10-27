using UnityEngine;

public class PlayerGoOut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private SoundMNG soundMNG;

    void OnTriggerEnter(Collider other)
    {


        if(other.CompareTag("Player"))  soundMNG.GoOutside();
    }
}
