using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyDeathSound, playerShootSound, playerJumpSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("CartoonSplatSoundEffect");
        playerShootSound = Resources.Load<AudioClip>("Shoot");
        playerJumpSound = Resources.Load<AudioClip>("Jump");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "Shoot":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            case "CartoonSplatSoundEffect":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;

        }

    }
}
