using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBaseHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 50;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip baseAttackAudio;
    void Start()
    {
        healthText.text = playerHealth.ToString();
    }
    public void OnTriggerEnter(Collider other)
    {
        PlayerHit();
        if(playerHealth <=0)
        {
            ProcessHit();
            print("You Lose");
        }
    }
    private void ProcessHit()
    {
        Destroy(gameObject);
    }
    void PlayerHit()
    {
        playerHealth = playerHealth - 5;
        GetComponent<AudioSource>().PlayOneShot(baseAttackAudio);
        healthText.text = playerHealth.ToString();
    }
}
