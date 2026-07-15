using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Diamond : MonoBehaviour
{
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] private int scoreValue = 25;
    [SerializeField] private AudioClip diamondSound;
    [SerializeField] private AudioSource audioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            AudioSource playerAudio = other.GetComponent<AudioSource>();

            if (playerAudio != null)
            {
                playerAudio.PlayOneShot(diamondSound);
            }

            ScoreManager.Instance.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
    
    
}
